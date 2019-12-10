pragma solidity ^0.5.11;
import "./nreAPI.sol";

contract Yahtzee  is usingNRE{
    address payable public  _owner;
    address public _partner;
    bool public _partnerJoined = false;
    uint public _stake;
    uint8 public _ownerDice1;
    uint8 public _ownerDice2;
    uint8 public _ownerDice3;
    uint8 public _ownerDice4;
    uint8 public _ownerDice5;
    uint8 public _partnerDice1;
    uint8 public _partnerDice2;
    uint8 public _partnerDice3;
    uint8 public _partnerDice4;
    uint8 public _partnerDice5;
    uint8 public _ownerThrows = 0;
    uint8 public _partnerThrows = 0;
    uint8 public _round = 1;
    uint8 private randomnessCounter = 0;
    mapping(uint8 => bool) public _ownerUsedScoring;
    mapping(uint8 => bool) public _partnerUsedScoring;
    mapping(uint8 => ScoringOption) public ScoringOptionIndex;
    uint16 _ownerScore = 0;
    uint16 _partnerScore = 0;
    uint256 _ownerLastSeen = 0;
    uint256 _partnerLastSeen = 0;


    enum ScoringOption {
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        ThreeOfAKind,
        FourOfAKind,
        FullHouse,
        SmallStreet,
        LargeStreet,
        Yahtzee,
        Chance
    }

    struct Message {
       bytes32 content;
       uint timestamp;
       address sender;
    }

    struct Inbox {
        uint numMessages;
        mapping (uint => Message) sentMessages;
        mapping (address => address) users;
    }

    mapping (address => Inbox) userInbox;

    Inbox newInbox;
    Message newMessage;

    constructor (address payable partner, uint stake) public payable {
        require(msg.value >= stake, "Not enough stake provided");

        _owner = msg.sender;
        _partner = partner;

        _ownerLastSeen = block.number;
        _partnerLastSeen = block.number;

        ScoringOptionIndex[0] = ScoringOption.One;
        ScoringOptionIndex[1] = ScoringOption.Two;
        ScoringOptionIndex[2] = ScoringOption.Three;
        ScoringOptionIndex[3] = ScoringOption.Four;
        ScoringOptionIndex[4] = ScoringOption.Five;
        ScoringOptionIndex[5] = ScoringOption.Six;
        ScoringOptionIndex[6] = ScoringOption.ThreeOfAKind;
        ScoringOptionIndex[7] = ScoringOption.FourOfAKind;
        ScoringOptionIndex[8] = ScoringOption.FullHouse;
        ScoringOptionIndex[9] = ScoringOption.SmallStreet;
        ScoringOptionIndex[10] = ScoringOption.LargeStreet;
        ScoringOptionIndex[11] = ScoringOption.Yahtzee;
        ScoringOptionIndex[12] = ScoringOption.Chance;

        userInbox[_owner] = newInbox;
        userInbox[_partner] = newInbox;
        newInbox.users[_owner] = _partner;
        newInbox.numMessages = 0;

    }

    function abortGame() public {
        require(msg.sender == _owner, "Access denied");
        require(!_partnerJoined, "Game has already started");

        _owner.transfer(_stake);
    }

    function joinGame() public payable {
        require(msg.sender == _partner, "Access denied");
        require(msg.value >= _stake, "Not enough stake provided");

        _partnerJoined = true;
    }

    function throwFirst() public {
        if(msg.sender == _owner)
        {
            require(_ownerThrows == 0, "Already rolled once");

            _ownerLastSeen = block.number;

            _ownerDice1 = getRandomDice();
            _ownerDice2 = getRandomDice();
            _ownerDice3 = getRandomDice();
            _ownerDice4 = getRandomDice();
            _ownerDice5 = getRandomDice();
            _ownerThrows = 1;
        }
        else if(msg.sender == _partner)
        {
            require(_partnerThrows == 0, "Already rolled once");

            _partnerLastSeen = block.number;

            _partnerDice1 = getRandomDice();
            _partnerDice2 = getRandomDice();
            _partnerDice3 = getRandomDice();
            _partnerDice4 = getRandomDice();
            _partnerDice5 = getRandomDice();
            _partnerThrows = 1;
        }
        else
            require(false, "Access denied");
    }

    function throwLater(bool throwDice1, bool throwDice2, bool throwDice3, bool throwDice4, bool throwDice5) public {
        if(msg.sender == _owner)
        {
            require(_ownerThrows >= 0, "Already rolled once");
            require(_ownerThrows < 3, "No more rolls available");

            _ownerLastSeen = block.number;

            if(throwDice1)
                _ownerDice1 = getRandomDice();
            if(throwDice2)
                _ownerDice2 = getRandomDice();
            if(throwDice3)
                _ownerDice3 = getRandomDice();
            if(throwDice4)
                _ownerDice4 = getRandomDice();
            if(throwDice5)
                _ownerDice5 = getRandomDice();

            _ownerThrows++;
        }
        else if(msg.sender == _partner)
        {
            require(_partnerThrows >= 0, "Already rolled once");
            require(_partnerThrows < 3, "No more rolls available");

            _partnerLastSeen = block.number;

            if(throwDice1)
                _partnerDice1 = getRandomDice();
            if(throwDice2)
                _partnerDice2 = getRandomDice();
            if(throwDice3)
                _partnerDice3 = getRandomDice();
            if(throwDice4)
                _partnerDice4 = getRandomDice();
            if(throwDice5)
                _partnerDice5 = getRandomDice();

            _partnerThrows++;
        }
        else
            require(false, "Access denied");
    }

    function getCurrentDices() public view returns (uint8, uint8, uint8, uint8, uint8) {
        if(msg.sender == _owner)
        {
            return (_ownerDice1, _ownerDice2, _ownerDice3, _ownerDice4, _ownerDice5);
        }
        else if(msg.sender == _partner)
        {
            return (_partnerDice1, _partnerDice2, _partnerDice3, _partnerDice4, _partnerDice5);
        }
        else
            require(false, "Access denied");
    }

    function getCurrentRoundNo() public view returns (uint8) {
        if(msg.sender == _owner)
        {
            return _round;
        }
    }

    function assignResult(ScoringOption scoringChoice,
                    bool scoringHelpDice1, bool scoringHelpDice2, bool scoringHelpDice3, bool scoringHelpDice4, bool scoringHelpDice5)
                    public {
        uint8 scoringIndex = getScoringIndex(scoringChoice);
        if(msg.sender == _owner)
        {
            require(!_ownerUsedScoring[scoringIndex], "Scoring was already used");
            require(_ownerThrows > 0, "Must throw dice before scoring");

            _ownerLastSeen = block.number;

            _ownerUsedScoring[scoringIndex] = true;
            _ownerScore += getPoints(
                _ownerDice1, _ownerDice2, _ownerDice3, _ownerDice4, _ownerDice5,
                scoringChoice,
                scoringHelpDice1, scoringHelpDice2, scoringHelpDice3, scoringHelpDice4, scoringHelpDice5);
            _ownerThrows = 0;
        }
        else if(msg.sender == _partner)
        {
            require(!_partnerUsedScoring[scoringIndex], "Scoring was already used");
            require(_partnerThrows > 0, "Must throw dice before scoring");

            _partnerLastSeen = block.number;

            _partnerUsedScoring[scoringIndex] = true;
            _partnerScore += getPoints(
                _partnerDice1, _partnerDice2, _partnerDice3, _partnerDice4, _partnerDice5,
                scoringChoice,
                scoringHelpDice1, scoringHelpDice2, scoringHelpDice3, scoringHelpDice4, scoringHelpDice5);
            _partnerThrows = 0;
        }
        else
            require(false, "Access denied");

        _round++;
    }

    function getPoints05(uint8 dice1, uint8 dice2, uint8 dice3, uint8 dice4, uint8 dice5, uint8 scoringChoice) private pure returns (uint8) {
        uint8 score = 0;

        if(dice1 == scoringChoice)
            score += dice1;
        if(dice2 == scoringChoice)
            score += dice2;
        if(dice3 == scoringChoice)
            score += dice3;
        if(dice4 == scoringChoice)
            score += dice4;
        if(dice5 == scoringChoice)
            score += dice5;

        return score;
    }

    function getPoints6(uint8 dice1, uint8 dice2, uint8 dice3, uint8 dice4, uint8 dice5,
                    uint8 scoringHelpDices)
                    private pure returns (uint8) {
            uint8 value = 0;
            uint8 dices = 0;
            if(scoringHelpDices & 1 == 1) {
                value = dice1;
                dices++;
            }
            if(scoringHelpDices & 2 == 2) {
                if(value == 0) {
                    value = dice2;
                    dices++;
                }
                else if(value == dice2)
                    dices++;
            }
            if(scoringHelpDices & 4 == 4) {
                if(value == 0) {
                    value = dice3;
                    dices++;
                }
                else if(value == dice3)
                    dices++;
            }
            if(scoringHelpDices & 8 == 8) {
                if(value == dice4)
                    dices++;
            }
            if(scoringHelpDices & 16 == 16) {
                if(value == dice5)
                    dices++;
            }
            if(dices >= 3) {
                return dice1 + dice2 + dice3 + dice4 + dice5;
            }
            else
                return 0;
    }

    function getPoints7(uint8 dice1, uint8 dice2, uint8 dice3, uint8 dice4, uint8 dice5,
                    uint8 scoringHelpDices
                    ) private pure returns (uint8) {
        uint8 value = 0;
        uint8 dices = 0;
        if(scoringHelpDices & 1 == 1) {
            value = dice1;
            dices++;
        }
        if(scoringHelpDices & 2 == 2) {
            if(value == 0) {
                value = dice2;
                dices++;
            }
            else if(value == dice2)
                dices++;
        }
        if(scoringHelpDices & 4 == 4) {
            if(value == dice3)
                dices++;
        }
        if(scoringHelpDices & 8 == 8) {
            if(value == dice4)
                dices++;
        }
        if(scoringHelpDices & 16 == 16) {
            if(value == dice5)
                dices++;
        }
        if(dices >= 4)
            return dice1 + dice2 + dice3 + dice4 + dice5;
        return 0;
    }

    function getPoints8(uint8 dice1, uint8 dice2, uint8 dice3, uint8 dice4, uint8 dice5,
                    bool scoringHelpDice1, bool scoringHelpDice2, bool scoringHelpDice3, bool scoringHelpDice4, bool scoringHelpDice5)
                    private pure returns (uint8) {
        uint8 mainValue = 0;
        uint8 mainDices = 0;
        uint8 otherValue = 0;
        uint8 otherDices = 0;

        if(scoringHelpDice1) {
            if(mainValue == 0) {
                mainValue = dice1;
                mainDices++;
            }
            else if(mainValue == dice1) {
                mainDices++;
            }
            else
                return 0;
        }
        else {
            if(otherValue == 0) {
                otherValue = dice1;
                otherDices++;
            }
            else if(otherValue == dice1) {
                otherDices++;
            }
            else
                return 0;
        }
        if(scoringHelpDice2) {
            if(mainValue == 0) {
                mainValue = dice2;
                mainDices++;
            }
            else if(mainValue == dice2) {
                mainDices++;
            }
            else
                return 0;
        }
        else {
            if(otherValue == 0) {
                otherValue = dice2;
                otherDices++;
            }
            else if(otherValue == dice2) {
                otherDices++;
            }
            else
                return 0;
        }
        if(scoringHelpDice3) {
            if(mainValue == 0) {
                mainValue = dice3;
                mainDices++;
            }
            else if(mainValue == dice3){
                mainDices++;
            }
            else
                return 0;
        }
        else {
            if(otherValue == 0) {
                otherValue = dice3;
                otherDices++;
            }
            else if(otherValue == dice3) {
                otherDices++;
            }
            else
                return 0;
        }
        if(scoringHelpDice4) {
            if(mainValue == 0) {
                mainValue = dice4;
                mainDices++;
            }
            else if(mainValue == dice4) {
                mainDices++;
            }
            else
                return 0;
        }
        else {
            if(otherValue == 0) {
                otherValue = dice4;
                otherDices++;
            }
            else if(otherValue == dice4) {
                otherDices++;
            }
            else
                return 0;
        }
        if(scoringHelpDice5) {
            if(mainValue == 0) {
                mainValue = dice5;
                mainDices++;
            }
            else if(mainValue == dice5){
                mainDices++;
            }
            else
                return 0;
        }
        else {
            if(otherValue == 0) {
                otherValue = dice5;
                otherDices++;
            }
            else if(otherValue == dice5) {
                otherDices++;
            }
            return 0;
        }
        return 25;
    }

    function getPoints9(uint8 dice1, uint8 dice2, uint8 dice3, uint8 dice4, uint8 dice5) private pure returns (uint8) {
        if(
            (
                contains(3, dice1, dice2, dice3, dice4, dice5) &&
                contains(4, dice1, dice2, dice3, dice4, dice5)
            ) &&
            (
                (
                    contains(1, dice1, dice2, dice3, dice4, dice5) &&
                    contains(2, dice1, dice2, dice3, dice4, dice5)
                ) ||
                (
                    contains(2, dice1, dice2, dice3, dice4, dice5) &&
                    contains(5, dice1, dice2, dice3, dice4, dice5)
                ) ||
                (
                    contains(5, dice1, dice2, dice3, dice4, dice5) &&
                    contains(6, dice1, dice2, dice3, dice4, dice5)
                )
            ))
            return 30;
        else
            return 0;
    }

    function getPoints10(uint8 dice1, uint8 dice2, uint8 dice3, uint8 dice4, uint8 dice5) private pure returns (uint8) {
        if(
            (
                contains(2, dice1, dice2, dice3, dice4, dice5) &&
                contains(3, dice1, dice2, dice3, dice4, dice5) &&
                contains(4, dice1, dice2, dice3, dice4, dice5) &&
                contains(5, dice1, dice2, dice3, dice4, dice5)
            ) &&
            (
                contains(1, dice1, dice2, dice3, dice4, dice5) ||
                contains(6, dice1, dice2, dice3, dice4, dice5)
            ))
            return 40;
        else
            return 0;
    }

    function getPoints11(uint8 dice1, uint8 dice2, uint8 dice3, uint8 dice4, uint8 dice5) private pure returns (uint8) {
        if(dice1 == dice2 && dice1 == dice3 && dice1 == dice4 && dice1 == dice5)
            return 50;
        else
            return 0;
    }

    function getPoints12(uint8 dice1, uint8 dice2, uint8 dice3, uint8 dice4, uint8 dice5) private pure returns (uint8) {
        return dice1 + dice2 + dice3 + dice4 + dice5;
    }

    function getScoringHelpDicesAsFlags(
        bool scoringHelpDice1, bool scoringHelpDice2, bool scoringHelpDice3, bool scoringHelpDice4, bool scoringHelpDice5)
        private pure returns (uint8) {
            uint8 scoringHelpDices = 0;
            if(scoringHelpDice1)
                scoringHelpDices |= 1;
            if(scoringHelpDice2)
                scoringHelpDices |= 2;
            if(scoringHelpDice3)
                scoringHelpDices |= 4;
            if(scoringHelpDice4)
                scoringHelpDices |= 8;
            if(scoringHelpDice5)
                scoringHelpDices |= 16;

            return scoringHelpDices;
    }

    function getPoints(uint8 dice1, uint8 dice2, uint8 dice3, uint8 dice4, uint8 dice5,
                    ScoringOption scoring,
                    bool scoringHelpDice1, bool scoringHelpDice2, bool scoringHelpDice3, bool scoringHelpDice4, bool scoringHelpDice5)
                    private view returns (uint8) {
        uint8 scoringIndex = getScoringIndex(scoring);
        if(scoringIndex >= 0 && scoringIndex <= 5)
            return getPoints05(dice1, dice2, dice3, dice4, dice5, scoringIndex + 1);
        else if(scoringIndex == 6)
        {
            uint8 scoringHelpDices = getScoringHelpDicesAsFlags(scoringHelpDice1, scoringHelpDice2, scoringHelpDice3, scoringHelpDice4, scoringHelpDice5);
            return getPoints6(dice1, dice2, dice3, dice4, dice5, scoringHelpDices);
        }
        else if(scoringIndex == 7)
        {
            uint8 scoringHelpDices = getScoringHelpDicesAsFlags(scoringHelpDice1, scoringHelpDice2, scoringHelpDice3, scoringHelpDice4, scoringHelpDice5);
            return getPoints7(dice1, dice2, dice3, dice4, dice5, scoringHelpDices);
        }
        else if(scoringIndex == 8)
        {
            return getPoints8(dice1, dice2, dice3, dice4, dice5, scoringHelpDice1, scoringHelpDice2, scoringHelpDice3, scoringHelpDice4, scoringHelpDice5);
        }
        else if(scoringIndex == 9) {
            return getPoints9(dice1, dice2, dice3, dice4, dice5);
        }
        else if(scoringIndex == 10) {
            return getPoints10(dice1, dice2, dice3, dice4, dice5);
        }
        else if(scoringIndex == 11) {
            return getPoints11(dice1, dice2, dice3, dice4, dice5);
        }
        return getPoints12(dice1, dice2, dice3, dice4, dice5);
    }

    function contains(uint8 value, uint8 dice1, uint8 dice2, uint8 dice3, uint8 dice4, uint8 dice5) private pure returns (bool) {
        return value == dice1 || value == dice2 || value == dice3 || value == dice4 || value == dice5;
    }

    function getScoringIndex(ScoringOption scoringOption) private view returns (uint8)  {
        for(uint8 i = 0; i < 12; i++)
        {
            if(scoringOption == ScoringOptionIndex[i])
                return i;
        }
    }

    function getRandomDice() private returns (uint8) {
        uint8 result;
        if (randomnessCounter == 0) {

            result = uint8((ra() % 6) + 1);

        }else if (randomnessCounter == 1) {

            result = uint8((rb() % 6) + 1);

        }else if (randomnessCounter == 2) {

            result = uint8((rc() % 6) + 1);

        }else if (randomnessCounter == 3) {

            result = uint8((rd() % 6) + 1);

        }else if (randomnessCounter == 4) {

            result = uint8((re() % 6) + 1);

        }else if (randomnessCounter == 5) {

            result = uint8((rf() % 6) + 1);

        }else if (randomnessCounter == 6) {

            result = uint8((rg() % 6) + 1);

        }else if (randomnessCounter == 7) {

            result = uint8((rh() % 6) + 1);

        }else if (randomnessCounter == 8) {

            result = uint8((ri() % 6) + 1);

        }else if (randomnessCounter == 9) {

            result = uint8((rj() % 6) + 1);

        }else if (randomnessCounter == 10) {

            result = uint8((rk() % 6) + 1);

        }else if (randomnessCounter == 11) {

            result = uint8((rl() % 6) + 1);

        }else if (randomnessCounter == 12) {

            result = uint8((rm() % 6) + 1);

        }else if (randomnessCounter == 13) {

            result = uint8((rn() % 6) + 1);

        }else if (randomnessCounter == 14) {

            result = uint8((ro() % 6) + 1);

        }else if (randomnessCounter == 15) {

            result = uint8((rp() % 6) + 1);

        }else if (randomnessCounter == 16) {

            result = uint8((rq() % 6) + 1);

        }else if (randomnessCounter == 17) {

            result = uint8((rr() % 6) + 1);

        }else if (randomnessCounter == 18) {

            result = uint8((rs() % 6) + 1);

        }else if (randomnessCounter == 19) {

            result = uint8((rt() % 6) + 1);

        }else if (randomnessCounter == 20) {

            result = uint8((ru() % 6) + 1);

        }else if (randomnessCounter == 21) {

            result = uint8((rv() % 6) + 1);

        }else if (randomnessCounter == 22) {

            result = uint8((rw() % 6) + 1);

        }else if (randomnessCounter == 23) {

            result = uint8((rx() % 6) + 1);

        }

        randomnessCounter = (randomnessCounter + 1) % 24;
        return result;
    }

    function sendMessage(bytes32 _content) public {
        newMessage.content = _content;
        newMessage.timestamp = now;
        newMessage.sender = _owner;

        Inbox storage sharedInbox = userInbox[msg.sender];
        sharedInbox.sentMessages[sharedInbox.numMessages] = newMessage;
        sharedInbox.numMessages++;

        return;
    }


    function receiveMessages() public view returns (bytes32[16] memory, uint[] memory, address[] memory) {
        Inbox storage sharedInbox = userInbox[msg.sender];
        bytes32[16] memory content;
        address[] memory sender = new address[](16);
        uint[] memory timestamp = new uint[](16);

        for (uint m = 0; m<15; m++) {
            Message memory message = sharedInbox.sentMessages[m];
            content[m] = message.content;
            sender[m] = message.sender;
            timestamp[m] = message.timestamp;
        }
    return (content, timestamp, sender);
    }

    // function examples() private view  {
    //     address anAddress;
    //     if(msg.sender==anAddress){}
    //     gasleft();
    // }
}
// pragma solidity >=0.4.0 <0.7.0;

// contract Yahtzee {
//     uint storedData;

//     function set(uint x) public {
//         storedData = x;
//     }

//     function get() public view returns (uint) {
//         return storedData;
//     }
// }
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

    constructor (address payable partner, uint stake) public payable {
        require(msg.value >= stake, "Not enough stake provided");
        _owner = msg.sender;
        _partner = partner;
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

    function assignResult(ScoringOption scoringChoice) public view{
        if(msg.sender == _owner)
        {

        }
        else if(msg.sender == _partner)
        {

        }
        else
            require(false, "Access denied");
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

    //function rollDice() public view returns(uint8[5] memory) {
	//	uint8[5] memory dice;
	//	dice[0] = uint8((ra() % 6) + 1);
	//	dice[1] = uint8((rb() % 6) + 1);
	//	dice[2] = uint8((rc() % 6) + 1);
	//	dice[3] = uint8((rd() % 6) + 1);
	//	dice[4] = uint8((rd() % 6) + 1);

	//	return dice;
	//}


    // function examples() private view  {
    //     address anAddress;
    //     if(msg.sender==anAddress){}
    //     gasleft();
    // }
}
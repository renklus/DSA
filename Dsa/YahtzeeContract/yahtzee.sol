pragma solidity >=0.4.0 <0.7.0;

contract Yahtzee {
    uint storedData;

    function set(uint x) public {
        storedData = x;
    }

    function get() public view returns (uint) {
        return storedData;
    }
}
// pragma solidity ^0.5.11;

// contract Yahtzee {
//     address payable public  _owner = address(0);
//     address public _partner = address(0);
//     bool public _partnerJoined = false;
//     uint public _stake;

//     constructor (address payable partner, uint stake) public payable {
//         require(msg.value >= stake, "Not enough stake provided");
//         _owner = msg.sender;
//         _partner = partner;
//     }

//     function abortGame() public {
//         require(msg.sender == _owner, "Access denied");
//         require(!_partnerJoined, "Game has already started");

//         _owner.transfer(_stake);
//     }

//     function joinGame(uint stake) public payable {
//         require(msg.sender == _partner, "Access denied");
//         require(msg.value >= stake, "Not enough stake provided");

//         _partnerJoined = true;
//     }

//     // function startGame() public {
//     //     require(msg.sender == _owner, "Access denied");
//     //     require(_partnerJoined, "Wait for partner");


//     // }


//     // function examples() private view  {
//     //     address anAddress;
//     //     if(msg.sender==anAddress){}
//     //     gasleft();
//     // }
// }
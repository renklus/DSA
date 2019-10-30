pragma solidity ^0.5.11;

contract Yahtzee {
    address payable _owner;
    address _partner;
    bool _partnerJoined = false;
    uint _stake;

    function () external payable { }

    constructor (address payable me, address partner, uint stake) public payable {
        require(msg.value >= stake, "Not enough stake provided");
        _owner = me;
        _partner = partner;
    }

    function abortGame() public {
        require(msg.sender == _owner, "Access denied");
        require(!_partnerJoined, "Game has already started");

        _owner.transfer(_stake);
    }

    function joinGame(uint stake) public payable {
        require(msg.sender == _partner, "Access denied");
        require(msg.value >= stake, "Not enough stake provided");

        _partnerJoined = true;
    }

    function startGame() public {
        require(msg.sender == _owner, "Access denied");
        require(_partnerJoined, "Wait for partner");


    }


    function examples() private view  {
        address anAddress;
        if(msg.sender==anAddress){}
        gasleft();
    }
}
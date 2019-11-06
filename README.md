# Step by step
https://medium.com/coinmonks/a-net-developers-workflow-for-creating-and-calling-ethereum-smart-contracts-44714f191db2

# Installationsanleitung
Visual Studio Code mit dem Plugin 'solidity' (https://marketplace.visualstudio.com/items?itemName=JuanBlanco.solidity) wird verwendet um den Solidity Contract zu schreiben. Das Plugin erstellt aus dem .sol File .abi und .bin Files.

Visual Studio IDE generiert aus den .abi und .bin Files die notwendige C# API.

Im Projekt 'Settings' braucht es drei Textfiles. PrivateAddress.txt mit der eigenen Ethereum Adresse, PrivateKey.txt mit dem privaten Schlüssel zur Adresse und Web3Url.txt mit der URL zu Infura.

# Übersicht
Wenn das Projekt 'Frontend' gestartet wird, geht ein Fenster auf. Durch drücken auf den Button wird ein Solidity Contract deployt.

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace YahtzeeContract.Yahtzee.ContractDefinition
{


    public partial class YahtzeeDeployment : YahtzeeDeploymentBase
    {
        public YahtzeeDeployment() : base(BYTECODE) { }
        public YahtzeeDeployment(string byteCode) : base(byteCode) { }
    }

    public class YahtzeeDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60806040819052600080546001600160a01b03191673031eae8a8105217ab64359d4361022d0947f45721781556002805460ff60a01b191690556004805460ff60681b1962ffffff60501b199091166c01000000000000000000000000171690556008805463ffffffff191690556009819055600a55612afa388190039081908339818101604052604081101561009557600080fd5b5080516020909101513481111561010d57604080517f08c379a000000000000000000000000000000000000000000000000000000000815260206004820152601960248201527f4e6f7420656e6f756768207374616b652070726f766964656400000000000000604482015290519081900360640190fd5b50600180546001600160a01b03199081163317808355600280546001600160a01b03958616908416178155436009818155600a9182557f6d5257204ebe7d88fd91ae87941cb2dd9d8062b64ae5a2bd2d28ec40b9fbf6df805460ff199081169091557fb39221ace053465ec3453ce2b36430bd138b997ecea25c1043da0c366812b82880548216881790557fb7c774451310d1be4108bc180d1b52823cb0ee0274a6c0081bcaf94f115fb96d80548216851790557f3be6fd20d5acfde5b873b48692cd31f4d3c7e8ee8a813af4696af8859e5ca6c68054821660031790557fb805995a7ec585a251200611a61d179cfd7fb105e1ab17dc415a7336783786f78054821660041790557fbcdda56b5d08466ec462cbbe0adfa57cb0a15fcc8940ef68f702f21b787bc9358054821660051790557f55c5b153ab560fcde54a63b18c7f53d75501706907cef8767fbded79ab9997c78054821660061790557fb7c49cceb9f85950584035457a41ebbd8cf93b9b612733ad25aa9731ac43aad68054821660071790557f4b1bf46c9f1bd48ff8274d40bad76a6615cb6c59a637d451a3994194b2db86be8054821660081790557ff1f3e9c34634a546b3672c043f73844d83d55591bbe61b8e7e3a72bca1a812bf805482169092179091557f3ed157e83ab1bb1f6b7b3760b3368106283d4e15d1f1b08e20d06576445a9994805482169092179091557fb7511a2dbe1513c8574eaafb5266301ff1bbf641d4144b093d6d1b500334bf2f80548216600b9081179091557f74b6357e277c778e8ad9a2761a935d45336ec91439b9e1b117eda2efdfe38fad8054909216600c908117909255928616600090815260209384526040808220835490819055845489168352818320559254955487168152600e9093529082208054949095169390921692909217909255908190556127359081906103c590396000f3fe6080604052600436106101c25760003560e01c806395bad4b1116100f7578063b2e1094011610095578063dffb4c5311610064578063dffb4c531461053a578063e12c9ca81461054f578063ec7d3e6414610579578063f361c4df14610651576101c2565b8063b2e109401461049b578063bf77e9b6146104b0578063d4f77b1c146104dd578063de92dd0d146104e5576101c2565b8063a9d3c5d8116100d1578063a9d3c5d814610419578063acc9b5b61461042e578063b02784b914610455578063b2bdfa7b1461046a576101c2565b806395bad4b1146103a3578063a561eb6e146103ef578063a876a8a014610404576101c2565b80636ddfb294116101645780637ec71e6b1161013e5780637ec71e6b1461031957806381e82b9f1461032e57806390506f201461037957806391db56821461038e576101c2565b80636ddfb294146102da5780636f869fa4146102ef57806372aa368b14610304576101c2565b80632843d50d116101a05780632843d50d14610270578063469384d71461029b5780635b722a4c146102b05780635ebed66e146102c5576101c2565b806308d69b8e146101c75780630d779610146101de578063229aa6201461021f575b600080fd5b3480156101d357600080fd5b506101dc610666565b005b3480156101ea57600080fd5b5061020b6004803603602081101561020157600080fd5b503560ff16610901565b604080519115158252519081900360200190f35b34801561022b57600080fd5b5061024c6004803603602081101561024257600080fd5b503560ff16610916565b6040518082600c81111561025c57fe5b60ff16815260200191505060405180910390f35b34801561027c57600080fd5b5061028561092b565b6040805160ff9092168252519081900360200190f35b3480156102a757600080fd5b50610285610953565b3480156102bc57600080fd5b5061020b610961565b3480156102d157600080fd5b50610285610971565b3480156102e657600080fd5b50610285610982565b3480156102fb57600080fd5b50610285610992565b34801561031057600080fd5b506102856109a2565b34801561032557600080fd5b506102856109b2565b34801561033a57600080fd5b506103436109c4565b6040805160ff96871681529486166020860152928516848401529084166060840152909216608082015290519081900360a00190f35b34801561038557600080fd5b506101dc610a70565b34801561039a57600080fd5b50610285610b5d565b3480156103af57600080fd5b506101dc600480360360a08110156103c657600080fd5b508035151590602081013515159060408101351515906060810135151590608001351515610b6d565b3480156103fb57600080fd5b50610285610e3b565b34801561041057600080fd5b50610285610e4a565b34801561042557600080fd5b50610285610e5a565b34801561043a57600080fd5b50610443610e6a565b60408051918252519081900360200190f35b34801561046157600080fd5b50610285610e70565b34801561047657600080fd5b5061047f610e80565b604080516001600160a01b039092168252519081900360200190f35b3480156104a757600080fd5b50610285610e8f565b3480156104bc57600080fd5b5061020b600480360360208110156104d357600080fd5b503560ff16610e9f565b6101dc610eb4565b3480156104f157600080fd5b506101dc600480360360c081101561050857600080fd5b5060ff81351690602081013515159060408101351515906060810135151590608081013515159060a001351515610f6f565b34801561054657600080fd5b5061047f61127e565b34801561055b57600080fd5b506101dc6004803603602081101561057257600080fd5b503561128d565b34801561058557600080fd5b5061058e611301565b604051808461020080838360005b838110156105b457818101518382015260200161059c565b505050509050018060200180602001838103835285818151815260200191508051906020019060200280838360005b838110156105fb5781810151838201526020016105e3565b50505050905001838103825284818151815260200191508051906020019060200280838360005b8381101561063a578181015183820152602001610622565b505050509050019550505050505060405180910390f35b34801561065d57600080fd5b5061028561143c565b6001546001600160a01b031633141561078f57600454600160501b900460ff16156106ce576040805162461bcd60e51b8152602060048201526013602482015272416c726561647920726f6c6c6564206f6e636560681b604482015290519081900360640190fd5b436009556106da611445565b6004805460ff191660ff929092169190911790556106f6611445565b600460016101000a81548160ff021916908360ff160217905550610718611445565b600460026101000a81548160ff021916908360ff16021790555061073a611445565b600460036101000a81548160ff021916908360ff16021790555061075c611445565b6004805460ff60501b1960ff939093166401000000000264ff00000000199091161791909116600160501b1790556108ff565b6002546001600160a01b03163314156108c257600454600160581b900460ff16156107f7576040805162461bcd60e51b8152602060048201526013602482015272416c726561647920726f6c6c6564206f6e636560681b604482015290519081900360640190fd5b43600a55610803611445565b600460056101000a81548160ff021916908360ff160217905550610825611445565b600460066101000a81548160ff021916908360ff160217905550610847611445565b600460076101000a81548160ff021916908360ff160217905550610869611445565b600460086101000a81548160ff021916908360ff16021790555061088b611445565b6004805460ff60581b1960ff93909316600160481b0269ff000000000000000000199091161791909116600160581b1790556108ff565b6040805162461bcd60e51b815260206004820152600d60248201526c1058d8d95cdcc819195b9a5959609a1b604482015290519081900360640190fd5b565b60056020526000908152604090205460ff1681565b60076020526000908152604090205460ff1681565b6001546000906001600160a01b03163314156109505750600454600160601b900460ff165b90565b600454610100900460ff1681565b600254600160a01b900460ff1681565b600454640100000000900460ff1681565b600454600160581b900460ff1681565b6004546301000000900460ff1681565b600454600160301b900460ff1681565b60045465010000000000900460ff1681565b60015460009081908190819081906001600160a01b0316331415610a1957505060045460ff80821694506101008204811693506201000082048116925063010000008204811691640100000000900416610a69565b6002546001600160a01b03163314156108c257505060045460ff65010000000000820481169450600160301b820481169350600160381b820481169250600160401b8204811691600160481b9004165b9091929394565b6001546001600160a01b03163314610abf576040805162461bcd60e51b815260206004820152600d60248201526c1058d8d95cdcc819195b9a5959609a1b604482015290519081900360640190fd5b600254600160a01b900460ff1615610b1e576040805162461bcd60e51b815260206004820152601860248201527f47616d652068617320616c726561647920737461727465640000000000000000604482015290519081900360640190fd5b6001546003546040516001600160a01b039092169181156108fc0291906000818181858888f19350505050158015610b5a573d6000803e3d6000fd5b50565b600454600160501b900460ff1681565b6001546001600160a01b0316331415610ccf576004546003600160501b90910460ff1610610bdc576040805162461bcd60e51b81526020600482015260176024820152764e6f206d6f726520726f6c6c7320617661696c61626c6560481b604482015290519081900360640190fd5b436009558415610c0357610bee611445565b6004805460ff191660ff929092169190911790555b8315610c2c57610c11611445565b600460016101000a81548160ff021916908360ff1602179055505b8215610c5557610c3a611445565b600460026101000a81548160ff021916908360ff1602179055505b8115610c7e57610c63611445565b600460036101000a81548160ff021916908360ff1602179055505b8015610ca657610c8c611445565b6004806101000a81548160ff021916908360ff1602179055505b60048054600160ff600160501b808404821692909201160260ff60501b19909116179055610e34565b6002546001600160a01b03163314156108c2576004546003600160581b90910460ff1610610d3e576040805162461bcd60e51b81526020600482015260176024820152764e6f206d6f726520726f6c6c7320617661696c61626c6560481b604482015290519081900360640190fd5b43600a558415610d6b57610d50611445565b600460056101000a81548160ff021916908360ff1602179055505b8315610d9457610d79611445565b600460066101000a81548160ff021916908360ff1602179055505b8215610dbd57610da2611445565b600460076101000a81548160ff021916908360ff1602179055505b8115610de657610dcb611445565b600460086101000a81548160ff021916908360ff1602179055505b8015610e0f57610df4611445565b600460096101000a81548160ff021916908360ff1602179055505b60048054600160ff600160581b808404821692909201160260ff60581b199091161790555b5050505050565b60045462010000900460ff1681565b600454600160601b900460ff1681565b600454600160401b900460ff1681565b60035481565b600454600160381b900460ff1681565b6001546001600160a01b031681565b600454600160481b900460ff1681565b60066020526000908152604090205460ff1681565b6002546001600160a01b03163314610f03576040805162461bcd60e51b815260206004820152600d60248201526c1058d8d95cdcc819195b9a5959609a1b604482015290519081900360640190fd5b600354341015610f5a576040805162461bcd60e51b815260206004820152601960248201527f4e6f7420656e6f756768207374616b652070726f766964656400000000000000604482015290519081900360640190fd5b6002805460ff60a01b1916600160a01b179055565b6000610f7a8761177f565b6001549091506001600160a01b03163314156110dd5760ff8082166000908152600560205260409020541615610ff2576040805162461bcd60e51b815260206004820152601860248201527714d8dbdc9a5b99c81dd85cc8185b1c9958591e481d5cd95960421b604482015290519081900360640190fd5b600454600160501b900460ff16611050576040805162461bcd60e51b815260206004820152601e60248201527f4d757374207468726f772064696365206265666f72652073636f72696e670000604482015290519081900360640190fd5b4360095560ff8082166000908152600560205260409020805460ff191660011790556004546110ad9181811691610100810482169162010000820481169163010000008104821691640100000000909104168c8c8c8c8c8c6117d7565b6008805461ffff19811660ff9390931661ffff91821601169190911790556004805460ff60501b19169055611251565b6002546001600160a01b03163314156108c25760ff8082166000908152600660205260409020541615611152576040805162461bcd60e51b815260206004820152601860248201527714d8dbdc9a5b99c81dd85cc8185b1c9958591e481d5cd95960421b604482015290519081900360640190fd5b600454600160581b900460ff166111b0576040805162461bcd60e51b815260206004820152601e60248201527f4d757374207468726f772064696365206265666f72652073636f72696e670000604482015290519081900360640190fd5b43600a5560ff8082166000908152600660205260409020805460ff1916600117905560045461121791650100000000008204811691600160301b8104821691600160381b8204811691600160401b8104821691600160481b909104168c8c8c8c8c8c6117d7565b6008805463ffff000019811660ff93909316620100009182900461ffff9081169190910116029190911790556004805460ff60581b191690555b505060048054600160ff600160601b808404821692909201160260ff60601b199091161790555050505050565b6002546001600160a01b031681565b600f81905542601090815560018054601180546001600160a01b03199081166001600160a01b03938416178255336000908152600b60209081526040808320805484528088019092529091208781559554868601559154600295909501805490911694909216939093179055815401905550565b6113096126c1565b336000908152600b6020526040902060609081906113256126c1565b60408051601080825261022082019092526060916020820161020080388339505060408051601080825261022082019092529293506060929150602082016102008038833901905050905060005b600f81101561142f576113846126e0565b50600081815260018087016020908152604092839020835160608101855281548082529382015492810192909252600201546001600160a01b0316928101929092528583601081106113d257fe5b6020020152604081015184518590849081106113ea57fe5b60200260200101906001600160a01b031690816001600160a01b031681525050806020015183838151811061141b57fe5b602090810291909101015250600101611373565b5091969195509350915050565b60045460ff1681565b6004546000908190600160681b900460ff166114775760066114656118f1565b8161146c57fe5b06600101905061174e565b600454600160681b900460ff1660011415611496576006611465611971565b600454600160681b900460ff16600214156114b55760066114656119c0565b600454600160681b900460ff16600314156114d4576006611465611a0f565b60048054600160681b900460ff1614156114f2576006611465611a5e565b600454600160681b900460ff1660051415611511576006611465611aad565b600454600160681b900460ff1660061415611530576006611465611afc565b600454600160681b900460ff166007141561154f576006611465611b4b565b600454600160681b900460ff166008141561156e576006611465611b9a565b600454600160681b900460ff166009141561158d576006611465611be9565b600454600160681b900460ff16600a14156115ac576006611465611c38565b600454600160681b900460ff16600b14156115cb576006611465611c87565b600454600160681b900460ff16600c14156115ea576006611465611cd6565b60045460ff600160681b90910416600d141561160a576006611465611d25565b600454600160681b900460ff16600e1415611629576006611465611d74565b600454600160681b900460ff16600f1415611648576006611465611dc3565b600454600160681b900460ff1660101415611667576006611465611e12565b600454600160681b900460ff1660111415611686576006611465611e61565b600454600160681b900460ff16601214156116a5576006611465611eb0565b600454600160681b900460ff16601314156116c4576006611465611eff565b600454600160681b900460ff16601414156116e3576006611465611f4e565b600454600160681b900460ff1660151415611702576006611465611f9d565b600454600160681b900460ff1660161415611721576006611465611fec565b600454600160681b900460ff166017141561174e57600661174061203b565b8161174757fe5b0660010190505b600480546018600160681b80830460ff9081166001018116929092069091160260ff60681b19909116179055919050565b6000805b600c8160ff1610156117d05760ff80821660009081526007602052604090205416600c8111156117af57fe5b83600c8111156117bb57fe5b14156117c85790506117d2565b600101611783565b505b919050565b6000806117e38861177f565b905060058160ff1611611809576118018d8d8d8d8d8660010161208a565b9150506118e2565b8060ff166006141561183d57600061182488888888886120ef565b90506118348e8e8e8e8e86612130565b925050506118e2565b8060ff166007141561186857600061185888888888886120ef565b90506118348e8e8e8e8e86612207565b8060ff1660081415611886576118018d8d8d8d8d8c8c8c8c8c6122cf565b8060ff166009141561189f576118018d8d8d8d8d6124ce565b8060ff16600a14156118b8576118018d8d8d8d8d61258c565b8060ff16600b14156118d1576118018d8d8d8d8d612617565b6118de8d8d8d8d8d612662565b9150505b9b9a5050505050505050505050565b60008060009054906101000a90046001600160a01b03166001600160a01b0316632ee8a4a96040518163ffffffff1660e01b815260040160206040518083038186803b15801561194057600080fd5b505afa158015611954573d6000803e3d6000fd5b505050506040513d602081101561196a57600080fd5b5051905090565b60008060009054906101000a90046001600160a01b03166001600160a01b031663b6ae33d86040518163ffffffff1660e01b815260040160206040518083038186803b15801561194057600080fd5b60008060009054906101000a90046001600160a01b03166001600160a01b03166312f773326040518163ffffffff1660e01b815260040160206040518083038186803b15801561194057600080fd5b60008060009054906101000a90046001600160a01b03166001600160a01b0316633ca36f886040518163ffffffff1660e01b815260040160206040518083038186803b15801561194057600080fd5b60008060009054906101000a90046001600160a01b03166001600160a01b03166315d55b286040518163ffffffff1660e01b815260040160206040518083038186803b15801561194057600080fd5b60008060009054906101000a90046001600160a01b03166001600160a01b031663bac506e06040518163ffffffff1660e01b815260040160206040518083038186803b15801561194057600080fd5b60008060009054906101000a90046001600160a01b03166001600160a01b0316633baa4e2e6040518163ffffffff1660e01b815260040160206040518083038186803b15801561194057600080fd5b60008060009054906101000a90046001600160a01b03166001600160a01b031663046faf746040518163ffffffff1660e01b815260040160206040518083038186803b15801561194057600080fd5b60008060009054906101000a90046001600160a01b03166001600160a01b03166318d007fc6040518163ffffffff1660e01b815260040160206040518083038186803b15801561194057600080fd5b60008060009054906101000a90046001600160a01b03166001600160a01b031663d6d27ab56040518163ffffffff1660e01b815260040160206040518083038186803b15801561194057600080fd5b60008060009054906101000a90046001600160a01b03166001600160a01b031663f7f855606040518163ffffffff1660e01b815260040160206040518083038186803b15801561194057600080fd5b60008060009054906101000a90046001600160a01b03166001600160a01b0316639c8077106040518163ffffffff1660e01b815260040160206040518083038186803b15801561194057600080fd5b60008060009054906101000a90046001600160a01b03166001600160a01b031663510fc61a6040518163ffffffff1660e01b815260040160206040518083038186803b15801561194057600080fd5b60008060009054906101000a90046001600160a01b03166001600160a01b0316638d48c9c86040518163ffffffff1660e01b815260040160206040518083038186803b15801561194057600080fd5b60008060009054906101000a90046001600160a01b03166001600160a01b031663d919ac646040518163ffffffff1660e01b815260040160206040518083038186803b15801561194057600080fd5b60008060009054906101000a90046001600160a01b03166001600160a01b031663904c1e1f6040518163ffffffff1660e01b815260040160206040518083038186803b15801561194057600080fd5b60008060009054906101000a90046001600160a01b03166001600160a01b03166357230f956040518163ffffffff1660e01b815260040160206040518083038186803b15801561194057600080fd5b60008060009054906101000a90046001600160a01b03166001600160a01b03166312539cc36040518163ffffffff1660e01b815260040160206040518083038186803b15801561194057600080fd5b60008060009054906101000a90046001600160a01b03166001600160a01b03166372af7e5f6040518163ffffffff1660e01b815260040160206040518083038186803b15801561194057600080fd5b60008060009054906101000a90046001600160a01b03166001600160a01b0316634c5054416040518163ffffffff1660e01b815260040160206040518083038186803b15801561194057600080fd5b60008060009054906101000a90046001600160a01b03166001600160a01b0316639a13ff4c6040518163ffffffff1660e01b815260040160206040518083038186803b15801561194057600080fd5b60008060009054906101000a90046001600160a01b03166001600160a01b0316635ebd95af6040518163ffffffff1660e01b815260040160206040518083038186803b15801561194057600080fd5b60008060009054906101000a90046001600160a01b03166001600160a01b03166393e311ae6040518163ffffffff1660e01b815260040160206040518083038186803b15801561194057600080fd5b60008060009054906101000a90046001600160a01b03166001600160a01b031663bcb8b2806040518163ffffffff1660e01b815260040160206040518083038186803b15801561194057600080fd5b60008060ff888116908416141561209e5787015b8260ff168760ff1614156120af5786015b8260ff168660ff1614156120c05785015b8260ff168560ff1614156120d15784015b8260ff168460ff1614156120e25783015b90505b9695505050505050565b60008086156120fc576001175b8515612106576002175b8415612110576004175b831561211a576008175b8215612124576010175b90505b95945050505050565b6000808060018085161415612146578891506001015b600280851614156121765760ff821661216457879150600101612176565b8760ff168260ff161415612176576001015b600480851614156121a65760ff8216612194578691506001016121a6565b8660ff168260ff1614156121a6576001015b600880851614156121c3578560ff168260ff1614156121c3576001015b601080851614156121e0578460ff168260ff1614156121e0576001015b60038160ff16106121fc575050508585018401830182016120e5565b6000925050506120e5565b600080806001808516141561221d578891506001015b6002808516141561224d5760ff821661223b5787915060010161224d565b8760ff168260ff16141561224d576001015b6004808516141561226a578660ff168260ff16141561226a576001015b60088085161415612287578560ff168260ff161415612287576001015b601080851614156122a4578460ff168260ff1614156122a4576001015b60048160ff16106122c0575050508585018401830182016120e5565b50600098975050505050505050565b600080808080891561231c5760ff84166122f1578e9350600190920191612317565b8e60ff168460ff16141561230a57600190920191612317565b60009450505050506124c0565b612341565b60ff821661232f578e9150600101612341565b8e60ff168260ff16141561230a576001015b88156123775760ff841661235d578d9350600190920191612372565b8d60ff168460ff16141561230a576001909201915b61239c565b60ff821661238a578d915060010161239c565b8d60ff168260ff16141561230a576001015b87156123d25760ff84166123b8578c93506001909201916123cd565b8c60ff168460ff16141561230a576001909201915b6123f7565b60ff82166123e5578c91506001016123f7565b8c60ff168260ff16141561230a576001015b861561242d5760ff8416612413578b9350600190920191612428565b8b60ff168460ff16141561230a576001909201915b612452565b60ff8216612440578b9150600101612452565b8b60ff168260ff16141561230a576001015b85156124885760ff841661246e578a9350600190920191612483565b8a60ff168460ff16141561230a576001909201915b6124b7565b60ff821661249b578a915060010161230a565b8a60ff168260ff16141561230a5750600093506124c092505050565b60199450505050505b9a9950505050505050505050565b60006124df6003878787878761266c565b80156124f557506124f56004878787878761266c565b8015612577575061250b6001878787878761266c565b801561252157506125216002878787878761266c565b8061254c57506125366002878787878761266c565b801561254c575061254c6005878787878761266c565b8061257757506125616005878787878761266c565b801561257757506125776006878787878761266c565b156125845750601e612127565b506000612127565b600061259d6002878787878761266c565b80156125b357506125b36003878787878761266c565b80156125c957506125c96004878787878761266c565b80156125df57506125df6005878787878761266c565b801561260a57506125f56001878787878761266c565b8061260a575061260a6006878787878761266c565b1561258457506028612127565b60008460ff168660ff1614801561263357508360ff168660ff16145b801561264457508260ff168660ff16145b801561265557508160ff168660ff16145b1561258457506032612127565b9390920101010190565b60008560ff168760ff16148061268757508460ff168760ff16145b8061269757508360ff168760ff16145b806126a757508260ff168760ff16145b806120e257508160ff168760ff1614979650505050505050565b6040518061020001604052806010906020820280388339509192915050565b60408051606081018252600080825260208201819052918101919091529056fea265627a7a723158203a6a15b61df4bfff31d2590e930380aa75fea44389211293b64a3c8c3aaf8c5364736f6c634300050b0032";
        public YahtzeeDeploymentBase() : base(BYTECODE) { }
        public YahtzeeDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "partner", 1)]
        public virtual string Partner { get; set; }
        [Parameter("uint256", "stake", 2)]
        public virtual BigInteger Stake { get; set; }
    }

    public partial class ThrowFirstFunction : ThrowFirstFunctionBase { }

    [Function("throwFirst")]
    public class ThrowFirstFunctionBase : FunctionMessage
    {

    }

    public partial class OwnerUsedScoringFunction : OwnerUsedScoringFunctionBase { }

    [Function("_ownerUsedScoring", "bool")]
    public class OwnerUsedScoringFunctionBase : FunctionMessage
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class ScoringOptionIndexFunction : ScoringOptionIndexFunctionBase { }

    [Function("ScoringOptionIndex", "uint8")]
    public class ScoringOptionIndexFunctionBase : FunctionMessage
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class GetCurrentRoundNoFunction : GetCurrentRoundNoFunctionBase { }

    [Function("getCurrentRoundNo", "uint8")]
    public class GetCurrentRoundNoFunctionBase : FunctionMessage
    {

    }

    public partial class OwnerDice2Function : OwnerDice2FunctionBase { }

    [Function("_ownerDice2", "uint8")]
    public class OwnerDice2FunctionBase : FunctionMessage
    {

    }

    public partial class PartnerJoinedFunction : PartnerJoinedFunctionBase { }

    [Function("_partnerJoined", "bool")]
    public class PartnerJoinedFunctionBase : FunctionMessage
    {

    }

    public partial class OwnerDice5Function : OwnerDice5FunctionBase { }

    [Function("_ownerDice5", "uint8")]
    public class OwnerDice5FunctionBase : FunctionMessage
    {

    }

    public partial class PartnerThrowsFunction : PartnerThrowsFunctionBase { }

    [Function("_partnerThrows", "uint8")]
    public class PartnerThrowsFunctionBase : FunctionMessage
    {

    }

    public partial class OwnerDice4Function : OwnerDice4FunctionBase { }

    [Function("_ownerDice4", "uint8")]
    public class OwnerDice4FunctionBase : FunctionMessage
    {

    }

    public partial class PartnerDice2Function : PartnerDice2FunctionBase { }

    [Function("_partnerDice2", "uint8")]
    public class PartnerDice2FunctionBase : FunctionMessage
    {

    }

    public partial class PartnerDice1Function : PartnerDice1FunctionBase { }

    [Function("_partnerDice1", "uint8")]
    public class PartnerDice1FunctionBase : FunctionMessage
    {

    }

    public partial class GetCurrentDicesFunction : GetCurrentDicesFunctionBase { }

    [Function("getCurrentDices", typeof(GetCurrentDicesOutputDTO))]
    public class GetCurrentDicesFunctionBase : FunctionMessage
    {

    }

    public partial class AbortGameFunction : AbortGameFunctionBase { }

    [Function("abortGame")]
    public class AbortGameFunctionBase : FunctionMessage
    {

    }

    public partial class OwnerThrowsFunction : OwnerThrowsFunctionBase { }

    [Function("_ownerThrows", "uint8")]
    public class OwnerThrowsFunctionBase : FunctionMessage
    {

    }

    public partial class ThrowLaterFunction : ThrowLaterFunctionBase { }

    [Function("throwLater")]
    public class ThrowLaterFunctionBase : FunctionMessage
    {
        [Parameter("bool", "throwDice1", 1)]
        public virtual bool ThrowDice1 { get; set; }
        [Parameter("bool", "throwDice2", 2)]
        public virtual bool ThrowDice2 { get; set; }
        [Parameter("bool", "throwDice3", 3)]
        public virtual bool ThrowDice3 { get; set; }
        [Parameter("bool", "throwDice4", 4)]
        public virtual bool ThrowDice4 { get; set; }
        [Parameter("bool", "throwDice5", 5)]
        public virtual bool ThrowDice5 { get; set; }
    }

    public partial class OwnerDice3Function : OwnerDice3FunctionBase { }

    [Function("_ownerDice3", "uint8")]
    public class OwnerDice3FunctionBase : FunctionMessage
    {

    }

    public partial class RoundFunction : RoundFunctionBase { }

    [Function("_round", "uint8")]
    public class RoundFunctionBase : FunctionMessage
    {

    }

    public partial class PartnerDice4Function : PartnerDice4FunctionBase { }

    [Function("_partnerDice4", "uint8")]
    public class PartnerDice4FunctionBase : FunctionMessage
    {

    }

    public partial class StakeFunction : StakeFunctionBase { }

    [Function("_stake", "uint256")]
    public class StakeFunctionBase : FunctionMessage
    {

    }

    public partial class PartnerDice3Function : PartnerDice3FunctionBase { }

    [Function("_partnerDice3", "uint8")]
    public class PartnerDice3FunctionBase : FunctionMessage
    {

    }

    public partial class OwnerFunction : OwnerFunctionBase { }

    [Function("_owner", "address")]
    public class OwnerFunctionBase : FunctionMessage
    {

    }

    public partial class PartnerDice5Function : PartnerDice5FunctionBase { }

    [Function("_partnerDice5", "uint8")]
    public class PartnerDice5FunctionBase : FunctionMessage
    {

    }

    public partial class PartnerUsedScoringFunction : PartnerUsedScoringFunctionBase { }

    [Function("_partnerUsedScoring", "bool")]
    public class PartnerUsedScoringFunctionBase : FunctionMessage
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class JoinGameFunction : JoinGameFunctionBase { }

    [Function("joinGame")]
    public class JoinGameFunctionBase : FunctionMessage
    {

    }

    public partial class AssignResultFunction : AssignResultFunctionBase { }

    [Function("assignResult")]
    public class AssignResultFunctionBase : FunctionMessage
    {
        [Parameter("uint8", "scoringChoice", 1)]
        public virtual byte ScoringChoice { get; set; }
        [Parameter("bool", "scoringHelpDice1", 2)]
        public virtual bool ScoringHelpDice1 { get; set; }
        [Parameter("bool", "scoringHelpDice2", 3)]
        public virtual bool ScoringHelpDice2 { get; set; }
        [Parameter("bool", "scoringHelpDice3", 4)]
        public virtual bool ScoringHelpDice3 { get; set; }
        [Parameter("bool", "scoringHelpDice4", 5)]
        public virtual bool ScoringHelpDice4 { get; set; }
        [Parameter("bool", "scoringHelpDice5", 6)]
        public virtual bool ScoringHelpDice5 { get; set; }
    }

    public partial class PartnerFunction : PartnerFunctionBase { }

    [Function("_partner", "address")]
    public class PartnerFunctionBase : FunctionMessage
    {

    }

    public partial class SendMessageFunction : SendMessageFunctionBase { }

    [Function("sendMessage")]
    public class SendMessageFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "_content", 1)]
        public virtual byte[] Content { get; set; }
    }

    public partial class ReceiveMessagesFunction : ReceiveMessagesFunctionBase { }

    [Function("receiveMessages", typeof(ReceiveMessagesOutputDTO))]
    public class ReceiveMessagesFunctionBase : FunctionMessage
    {

    }

    public partial class OwnerDice1Function : OwnerDice1FunctionBase { }

    [Function("_ownerDice1", "uint8")]
    public class OwnerDice1FunctionBase : FunctionMessage
    {

    }



    public partial class OwnerUsedScoringOutputDTO : OwnerUsedScoringOutputDTOBase { }

    [FunctionOutput]
    public class OwnerUsedScoringOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class ScoringOptionIndexOutputDTO : ScoringOptionIndexOutputDTOBase { }

    [FunctionOutput]
    public class ScoringOptionIndexOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class GetCurrentRoundNoOutputDTO : GetCurrentRoundNoOutputDTOBase { }

    [FunctionOutput]
    public class GetCurrentRoundNoOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class OwnerDice2OutputDTO : OwnerDice2OutputDTOBase { }

    [FunctionOutput]
    public class OwnerDice2OutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class PartnerJoinedOutputDTO : PartnerJoinedOutputDTOBase { }

    [FunctionOutput]
    public class PartnerJoinedOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class OwnerDice5OutputDTO : OwnerDice5OutputDTOBase { }

    [FunctionOutput]
    public class OwnerDice5OutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class PartnerThrowsOutputDTO : PartnerThrowsOutputDTOBase { }

    [FunctionOutput]
    public class PartnerThrowsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class OwnerDice4OutputDTO : OwnerDice4OutputDTOBase { }

    [FunctionOutput]
    public class OwnerDice4OutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class PartnerDice2OutputDTO : PartnerDice2OutputDTOBase { }

    [FunctionOutput]
    public class PartnerDice2OutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class PartnerDice1OutputDTO : PartnerDice1OutputDTOBase { }

    [FunctionOutput]
    public class PartnerDice1OutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class GetCurrentDicesOutputDTO : GetCurrentDicesOutputDTOBase { }

    [FunctionOutput]
    public class GetCurrentDicesOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
        [Parameter("uint8", "", 2)]
        public virtual byte ReturnValue2 { get; set; }
        [Parameter("uint8", "", 3)]
        public virtual byte ReturnValue3 { get; set; }
        [Parameter("uint8", "", 4)]
        public virtual byte ReturnValue4 { get; set; }
        [Parameter("uint8", "", 5)]
        public virtual byte ReturnValue5 { get; set; }
    }



    public partial class OwnerThrowsOutputDTO : OwnerThrowsOutputDTOBase { }

    [FunctionOutput]
    public class OwnerThrowsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }



    public partial class OwnerDice3OutputDTO : OwnerDice3OutputDTOBase { }

    [FunctionOutput]
    public class OwnerDice3OutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class RoundOutputDTO : RoundOutputDTOBase { }

    [FunctionOutput]
    public class RoundOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class PartnerDice4OutputDTO : PartnerDice4OutputDTOBase { }

    [FunctionOutput]
    public class PartnerDice4OutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class StakeOutputDTO : StakeOutputDTOBase { }

    [FunctionOutput]
    public class StakeOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class PartnerDice3OutputDTO : PartnerDice3OutputDTOBase { }

    [FunctionOutput]
    public class PartnerDice3OutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class OwnerOutputDTO : OwnerOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class PartnerDice5OutputDTO : PartnerDice5OutputDTOBase { }

    [FunctionOutput]
    public class PartnerDice5OutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class PartnerUsedScoringOutputDTO : PartnerUsedScoringOutputDTOBase { }

    [FunctionOutput]
    public class PartnerUsedScoringOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }





    public partial class PartnerOutputDTO : PartnerOutputDTOBase { }

    [FunctionOutput]
    public class PartnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }



    public partial class ReceiveMessagesOutputDTO : ReceiveMessagesOutputDTOBase { }

    [FunctionOutput]
    public class ReceiveMessagesOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32[16]", "", 1)]
        public virtual List<byte[]> ReturnValue1 { get; set; }
        [Parameter("uint256[]", "", 2)]
        public virtual List<BigInteger> ReturnValue2 { get; set; }
        [Parameter("address[]", "", 3)]
        public virtual List<string> ReturnValue3 { get; set; }
    }

    public partial class OwnerDice1OutputDTO : OwnerDice1OutputDTOBase { }

    [FunctionOutput]
    public class OwnerDice1OutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }
}

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
        public static string BYTECODE = "608060408190526001805460ff60a01b191690556003805462ffffff60501b19166c01000000000000000000000000179055611062388190039081908339818101604052604081101561005157600080fd5b508051602090910151348111156100c957604080517f08c379a000000000000000000000000000000000000000000000000000000000815260206004820152601960248201527f4e6f7420656e6f756768207374616b652070726f766964656400000000000000604482015290519081900360640190fd5b50600080546001600160a01b031990811633178255600180546001600160a01b039490941693909116929092178255600660208190527f54cdd369e4e8a8515e52ca72ec816c2101831ad1f18bf44102ed171459c9b4f8805460ff199081169091557f3e5fec24aa4dc4e5aee2e025e51e1392c72a2500577559fae9665c6d52bd6a31805482169094179093557f8819ef417987f8ae7a81f42cdfb18815282fe989326fbff903d13cf0e03ace298054841660021790557f75f96ab15d697e93042dc45b5c896c4b27e89bb6eaf39475c5c371cb2513f7d28054841660031790557fc5069e24aaadb2addc3e52e868fcf3f4f8acf5a87e24300992fd4540c2a87eed8054841660041790557fbfd358e93f18da3ed276c3afdbdba00b8f0b6008a03476a6a86bd6320ee6938b8054841660051790557f697b2bd7bb2984c4e0dc14c79c987d37818484a62958b9c45a0e8b962f20650f8054841690911790557f4ced6d0d36392b04cc5d8761b1327b3bbba6e1089c77f60a9a9ca18e05e4f00e8054831660071790557fb8d683c9d414f481826f3e7fe14b3ac6ae8c73450778287390c4bb8cb9f2e80b8054831660081790557fca4d0c6c94a9477136dd41a99cc19ecbe441c8f6609efe7c6fa65be007a473238054831660091790557f4da38fc8e544afc56a4c2a17752b8ddb67d8e23ac4583c9029d2e2d1dbe6c98880548316600a1790557f85291c2e7881182c13e19eca9b58927ebfdc2c5d04882018eeb33d8241d3571180548316600b179055600c8082527f0b94fa1b86997cc1f1148bfbe25b674e8cefc7cc6f976aa8d7c7966bd4cca347805490931617909155610d2990819061033990396000f3fe6080604052600436106101665760003560e01c806391db5682116100d1578063b02784b91161008a578063bf77e9b611610064578063bf77e9b614610421578063d4f77b1c1461044e578063dffb4c5314610456578063f361c4df1461046b57610166565b8063b02784b9146103c6578063b2bdfa7b146103db578063b2e109401461040c57610166565b806391db5682146102ff57806395bad4b114610314578063a561eb6e14610360578063a876a8a014610375578063a9d3c5d81461038a578063acc9b5b61461039f57610166565b80635ebed66e116101235780635ebed66e146102815780636ddfb294146102965780636f869fa4146102ab57806372aa368b146102c05780637ec71e6b146102d557806390506f20146102ea57610166565b806308d69b8e1461016b5780630d77961014610182578063229aa620146101c3578063469384d7146102145780635b722a4c1461023f5780635c6a07c514610254575b600080fd5b34801561017757600080fd5b50610180610480565b005b34801561018e57600080fd5b506101af600480360360208110156101a557600080fd5b503560ff16610712565b604080519115158252519081900360200190f35b3480156101cf57600080fd5b506101f0600480360360208110156101e657600080fd5b503560ff16610727565b6040518082600c81111561020057fe5b60ff16815260200191505060405180910390f35b34801561022057600080fd5b5061022961073c565b6040805160ff9092168252519081900360200190f35b34801561024b57600080fd5b506101af61074a565b34801561026057600080fd5b506101806004803603602081101561027757600080fd5b503560ff1661075a565b34801561028d57600080fd5b50610229610789565b3480156102a257600080fd5b5061022961079a565b3480156102b757600080fd5b506102296107aa565b3480156102cc57600080fd5b506102296107ba565b3480156102e157600080fd5b506102296107cd565b3480156102f657600080fd5b506101806107df565b34801561030b57600080fd5b506102296108c8565b34801561032057600080fd5b50610180600480360360a081101561033757600080fd5b5080351515906020810135151590604081013515159060608101351515906080013515156108d8565b34801561036c57600080fd5b50610229610b9a565b34801561038157600080fd5b50610229610ba9565b34801561039657600080fd5b50610229610bb9565b3480156103ab57600080fd5b506103b4610bce565b60408051918252519081900360200190f35b3480156103d257600080fd5b50610229610bd4565b3480156103e757600080fd5b506103f0610be8565b604080516001600160a01b039092168252519081900360200190f35b34801561041857600080fd5b50610229610bf7565b34801561042d57600080fd5b506101af6004803603602081101561044457600080fd5b503560ff16610c07565b610180610c1c565b34801561046257600080fd5b506103f0610cd7565b34801561047757600080fd5b50610229610ce6565b6000546001600160a01b03163314156105a457600354600160501b900460ff16156104e8576040805162461bcd60e51b8152602060048201526013602482015272416c726561647920726f6c6c6564206f6e636560681b604482015290519081900360640190fd5b6104f0610cef565b6003805460ff191660ff9290921691909117905561050c610cef565b600360016101000a81548160ff021916908360ff16021790555061052e610cef565b600360026101000a81548160ff021916908360ff160217905550610550610cef565b6003806101000a81548160ff021916908360ff160217905550610571610cef565b6003805460ff60501b1960ff939093166401000000000264ff00000000199091161791909116600160501b179055610710565b6001546001600160a01b03163314156106d357600354600160581b900460ff161561060c576040805162461bcd60e51b8152602060048201526013602482015272416c726561647920726f6c6c6564206f6e636560681b604482015290519081900360640190fd5b610614610cef565b600360056101000a81548160ff021916908360ff160217905550610636610cef565b600360066101000a81548160ff021916908360ff160217905550610658610cef565b600360076101000a81548160ff021916908360ff16021790555061067a610cef565b600360086101000a81548160ff021916908360ff16021790555061069c610cef565b6003805460ff60581b1960ff93909316600160481b0269ff000000000000000000199091161791909116600160581b179055610710565b6040805162461bcd60e51b815260206004820152600d60248201526c1058d8d95cdcc819195b9a5959609a1b604482015290519081900360640190fd5b565b60046020526000908152604090205460ff1681565b60066020526000908152604090205460ff1681565b600354610100900460ff1681565b600154600160a01b900460ff1681565b6000546001600160a01b031633141561077257610786565b6001546001600160a01b03163314156106d3575b50565b600354640100000000900460ff1681565b600354600160581b900460ff1681565b6003546301000000900460ff1681565b6003546601000000000000900460ff1681565b60035465010000000000900460ff1681565b6000546001600160a01b0316331461082e576040805162461bcd60e51b815260206004820152600d60248201526c1058d8d95cdcc819195b9a5959609a1b604482015290519081900360640190fd5b600154600160a01b900460ff161561088d576040805162461bcd60e51b815260206004820152601860248201527f47616d652068617320616c726561647920737461727465640000000000000000604482015290519081900360640190fd5b600080546002546040516001600160a01b039092169281156108fc029290818181858888f19350505050158015610786573d6000803e3d6000fd5b600354600160501b900460ff1681565b6000546001600160a01b0316331415610a345760038054600160501b900460ff1610610945576040805162461bcd60e51b81526020600482015260176024820152764e6f206d6f726520726f6c6c7320617661696c61626c6560481b604482015290519081900360640190fd5b841561096857610953610cef565b6003805460ff191660ff929092169190911790555b831561099157610976610cef565b600360016101000a81548160ff021916908360ff1602179055505b82156109ba5761099f610cef565b600360026101000a81548160ff021916908360ff1602179055505b81156109e2576109c8610cef565b6003806101000a81548160ff021916908360ff1602179055505b8015610a0b576109f0610cef565b600360046101000a81548160ff021916908360ff1602179055505b60038054600160ff600160501b808404821692909201160260ff60501b19909116179055610b93565b6001546001600160a01b03163314156106d35760038054600160581b900460ff1610610aa1576040805162461bcd60e51b81526020600482015260176024820152764e6f206d6f726520726f6c6c7320617661696c61626c6560481b604482015290519081900360640190fd5b8415610aca57610aaf610cef565b600360056101000a81548160ff021916908360ff1602179055505b8315610af357610ad8610cef565b600360066101000a81548160ff021916908360ff1602179055505b8215610b1c57610b01610cef565b600360076101000a81548160ff021916908360ff1602179055505b8115610b4557610b2a610cef565b600360086101000a81548160ff021916908360ff1602179055505b8015610b6e57610b53610cef565b600360096101000a81548160ff021916908360ff1602179055505b60038054600160ff600160581b808404821692909201160260ff60581b199091161790555b5050505050565b60035462010000900460ff1681565b600354600160601b900460ff1681565b60035468010000000000000000900460ff1681565b60025481565b600354670100000000000000900460ff1681565b6000546001600160a01b031681565b600354600160481b900460ff1681565b60056020526000908152604090205460ff1681565b6001546001600160a01b03163314610c6b576040805162461bcd60e51b815260206004820152600d60248201526c1058d8d95cdcc819195b9a5959609a1b604482015290519081900360640190fd5b600254341015610cc2576040805162461bcd60e51b815260206004820152601960248201527f4e6f7420656e6f756768207374616b652070726f766964656400000000000000604482015290519081900360640190fd5b6001805460ff60a01b1916600160a01b179055565b6001546001600160a01b031681565b60035460ff1681565b60019056fea265627a7a723158202d4141337b3574187a65946297e8bbc4706b188436ebc064ec8b83ca95a84c4964736f6c634300050b0032";
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

    public partial class AssignResultFunction : AssignResultFunctionBase { }

    [Function("assignResult")]
    public class AssignResultFunctionBase : FunctionMessage
    {
        [Parameter("uint8", "scoringChoice", 1)]
        public virtual byte ScoringChoice { get; set; }
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

    public partial class PartnerFunction : PartnerFunctionBase { }

    [Function("_partner", "address")]
    public class PartnerFunctionBase : FunctionMessage
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

    public partial class OwnerDice1OutputDTO : OwnerDice1OutputDTOBase { }

    [FunctionOutput]
    public class OwnerDice1OutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }
}

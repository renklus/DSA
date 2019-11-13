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
        public static string BYTECODE = "608060408190526001805460ff60a01b1916905561041d388190039081908339818101604052604081101561003357600080fd5b508051602090910151348111156100ab57604080517f08c379a000000000000000000000000000000000000000000000000000000000815260206004820152601960248201527f4e6f7420656e6f756768207374616b652070726f766964656400000000000000604482015290519081900360640190fd5b50600080546001600160a01b03199081163317909155600180546001600160a01b039390931692909116919091179055610333806100ea6000396000f3fe6080604052600436106100555760003560e01c80635b722a4c1461005a57806390506f2014610083578063acc9b5b61461009a578063b2bdfa7b146100c1578063dffb4c53146100f2578063efaa55a014610107575b600080fd5b34801561006657600080fd5b5061006f610124565b604080519115158252519081900360200190f35b34801561008f57600080fd5b50610098610134565b005b3480156100a657600080fd5b506100af610220565b60408051918252519081900360200190f35b3480156100cd57600080fd5b506100d6610226565b604080516001600160a01b039092168252519081900360200190f35b3480156100fe57600080fd5b506100d6610235565b6100986004803603602081101561011d57600080fd5b5035610244565b600154600160a01b900460ff1681565b6000546001600160a01b03163314610183576040805162461bcd60e51b815260206004820152600d60248201526c1058d8d95cdcc819195b9a5959609a1b604482015290519081900360640190fd5b600154600160a01b900460ff16156101e2576040805162461bcd60e51b815260206004820152601860248201527f47616d652068617320616c726561647920737461727465640000000000000000604482015290519081900360640190fd5b600080546002546040516001600160a01b039092169281156108fc029290818181858888f1935050505015801561021d573d6000803e3d6000fd5b50565b60025481565b6000546001600160a01b031681565b6001546001600160a01b031681565b6001546001600160a01b03163314610293576040805162461bcd60e51b815260206004820152600d60248201526c1058d8d95cdcc819195b9a5959609a1b604482015290519081900360640190fd5b803410156102e8576040805162461bcd60e51b815260206004820152601960248201527f4e6f7420656e6f756768207374616b652070726f766964656400000000000000604482015290519081900360640190fd5b506001805460ff60a01b1916600160a01b17905556fea265627a7a72315820e143fa0c3e2bdd159ba1e48a095bd39393c04b04f786e5217d243ff220408b5a64736f6c634300050b0032";
        public YahtzeeDeploymentBase() : base(BYTECODE) { }
        public YahtzeeDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "partner", 1)]
        public virtual string Partner { get; set; }
        [Parameter("uint256", "stake", 2)]
        public virtual BigInteger Stake { get; set; }
    }

    public partial class PartnerJoinedFunction : PartnerJoinedFunctionBase { }

    [Function("_partnerJoined", "bool")]
    public class PartnerJoinedFunctionBase : FunctionMessage
    {

    }

    public partial class AbortGameFunction : AbortGameFunctionBase { }

    [Function("abortGame")]
    public class AbortGameFunctionBase : FunctionMessage
    {

    }

    public partial class StakeFunction : StakeFunctionBase { }

    [Function("_stake", "uint256")]
    public class StakeFunctionBase : FunctionMessage
    {

    }

    public partial class OwnerFunction : OwnerFunctionBase { }

    [Function("_owner", "address")]
    public class OwnerFunctionBase : FunctionMessage
    {

    }

    public partial class PartnerFunction : PartnerFunctionBase { }

    [Function("_partner", "address")]
    public class PartnerFunctionBase : FunctionMessage
    {

    }

    public partial class JoinGameFunction : JoinGameFunctionBase { }

    [Function("joinGame")]
    public class JoinGameFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "stake", 1)]
        public virtual BigInteger Stake { get; set; }
    }

    public partial class PartnerJoinedOutputDTO : PartnerJoinedOutputDTOBase { }

    [FunctionOutput]
    public class PartnerJoinedOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }



    public partial class StakeOutputDTO : StakeOutputDTOBase { }

    [FunctionOutput]
    public class StakeOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class OwnerOutputDTO : OwnerOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class PartnerOutputDTO : PartnerOutputDTOBase { }

    [FunctionOutput]
    public class PartnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }


}

using System;
using AnkrSDK.Data;

namespace AnkrSDK.Provider
{
	public static class AnkrSDKFactoryHelper
	{
		public static string GetAnkrRPCForSelectedNetwork(NetworkName networkName)
		{
			switch (networkName)
			{
				case NetworkName.Ethereum:
					return "https://rpc.ankr.com/eth";
				case NetworkName.Rinkeby:
					return "https://rpc.ankr.com/eth_rinkeby";
				case NetworkName.Goerli:
					return "https://rpc.ankr.com/eth_goerli";
				case NetworkName.Ropsten:
					return "https://rpc.ankr.com/eth_ropsten";
				case NetworkName.BinanceSmartChain:
					return "https://rpc.ankr.com/bsc";
				case NetworkName.BinanceSmartChain_TestNet:
					default: throw new NotSupportedException();
			}
		}
	}
}
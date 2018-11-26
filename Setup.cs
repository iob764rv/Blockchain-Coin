using System;
using NBitcoin;
using System.Text;
using QBitNinja.Client;
using System.Threading.Tasks;


namespace blockchainfile
  
    class Program
    {
        static void Main(string[] args)
        {
          Network network = Network.TestNet;
          var treasurer = new BitcoinSecret("key")
          var alice = new BitcoinSecret("key");
          
          
          Console.WriteLine("treasurer key: " + treasurer.PrivateKey.GetWif(network));
          Console.WriteLine("Alice     key: " + alice.PrivateKey.GetWif(network));
           
        }
    }
}


  

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
          
          var scriptPubKey = PayToMultiSigTemplate
                .Instance
                .GenerateScriptPubKey(2, new[] { alice.PubKey, treasurer.PubKey });
          
          Console.WriteLine("PubKey script: " + scriptPubKey);
          
          var redeemScript = PayToMultiSigTemplate
            .Instance
            .GenerateScriptPubKey(2, new[] { bob.PubKey, alice.PubKey, treasurer.PubKey });

          var paymentScript = redeemScript.PaymentScript;
          Console.WriteLine("paymentScript: " + paymentScript);
          
          
          Console.WriteLine("multi-sig address: " + redeemScript.Hash.GetAddress(network));
          var client = new QBitNinjaClient(network);

            // Update
          var receiveTransactionId = uint256.Parse("yourid");
          var receiveTransactionResponse = client.GetTransaction(receiveTransactionId).Result;
          Console.WriteLine(receiveTransactionResponse.TransactionId);
         
          var receiveTransactionResponse = client.GetTransaction(receiveTransactionId).Result;

          Console.WriteLine(receiveTransactionResponse.TransactionId);
          Console.WriteLine(receiveTransactionResponse.Block.Confirmations);
           
          var receivedCoins = receiveTransactionResponse.ReceivedCoins;
          OutPoint outpointToSpend = null;
          ScriptCoin coinToSpend = null;
           
          foreach (var c in receivedCoins)
          {
                    try
                {
                    coinToSpend = new ScriptCoin(c.Outpoint, c.TxOut, redeemScript);
                    outpointToSpend = c.Outpoint;
                    break;
                }
                catch { }
           if (outpointToSpend == null)
                throw new Exception("TxOut doesn't contain any our ScriptPubKey");
                Console.WriteLine("outpoint #{0}");
            
          var lucasAddress = BitcoinAddress.Create("address", network);

            TransactionBuilder builder = network.CreateTransactionBuilder();

            var minerFee = new Money(0.0005m, MoneyUnit.BTC);
            var txInAmount = (Money)receivedCoins[(int)outpointToSpend.N].Amount;
            var sendAmount = txInAmount - minerFee;
            
               Transaction unsigned =
                builder
                    .AddCoins(coinToSpend)
                    .Send(lucasAddress, sendAmount)
                    .SetChange(lucasAddress, ChangeType.Uncolored)
                    .BuildTransaction(sign: false);
            
                 Transaction aliceSigned =
                builder
                    .AddCoins(coinToSpend)
                    .AddKeys(alice)
                   
                   
               Transaction bobSigned =
                builder
                    .AddCoins(coinToSpend)
                    .AddKeys(bob)
                    .SignTransaction(aliceSigned);
                    .SignTransaction(unsigned);
            
            
              Transaction fullySigned =
                builder
                    .AddCoins(coinToSpend)
                    .CombineSignatures(aliceSigned, bobSigned);

            Console.WriteLine(fullySigned);
            ]]
                        var broadcastResponse = client.Broadcast(fullySigned).Result;
            if (!broadcastResponse.Success)
            {
                Console.Error.WriteLine("ErrorCode: " + broadcastResponse.Error.ErrorCode);
                Console.Error.WriteLine("Error message: " + broadcastResponse.Error.Reason);
            }
            else
            {
                Console.WriteLine("Success! You can check out the hash of the transaciton in any block explorer:");
                Console.WriteLine(fullySigned.GetHash());
            }
        }
    }
}
            
            
            
          }
        }
    }
}


  

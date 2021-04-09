using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using System.Net;
using Telegram.Bot.Types;

namespace TelegramBotMessage
{
    class Program
    {
        static void Main(string[] args)
        {

            /*SCRIPT para el envio de  mensajes desde un bot de Telegram
                Tener en cuenta, que la forma en la que se envian los mensajes, es desde una consulta HTTP a la API de Telegram. La misma se realiza con el formato:
                -https://api.telegram.org/bot{tokenAPI}/sendMessage?chat_id={chat_id}&text={mensaje}
                 */

            /*Orden de los Argumentos:
                args[0] -> chatID (-345547283)
                agrs[1] -> Token (1785746650:AAEhZGWi9EC4_oGxTJRHI9-XZEnYFO3dEpM)
                args[2] -> Mensaje
             */

            //Agregar estas dos lineas para evitar excepciones
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            if (args.Length >= 3)
            {
                string token = args[0]; // "1785746650:AAEhZGWi9EC4_oGxTJRHI9-XZEnYFO3dEpM";
                string chatID = args[1]; //"-345547283";
                string mensaje = "";// = args[2];

                /*
                    El siguiente for se realiza ya que el mensaje viene separado por espacios, y C# entiende que son parametros distintos. 
                */
                for (int x = 2; x<args.Length; x ++)
                {
                    mensaje += args[x];
                    mensaje += " ";
                }

                string urlString = $"https://api.telegram.org/bot" + token + "/sendMessage?chat_id=" + chatID + "&text=" + mensaje;
                WebClient webCliente = new WebClient();

                string a = webCliente.DownloadString(urlString);
                /*Console.WriteLine("El request ejecutado fue: "+urlString);
                Console.WriteLine();
                Console.WriteLine("El response de la peticion fue: " + a );
                Console.WriteLine();*/
                //Console.ReadLine();
            }
        }
    }
}

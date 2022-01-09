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
                agrs[0]     -> Token (1785746650:AAEhZGWi9EC4_oGxTJRHI9-XZEnYFO3dEpM)
                args[1]     -> chatID (-345547283)
                args[2..n]  -> Mensaje
             */

            /*
            Algunos emojis que pueden ser de interes: ✅ ❌
            Para mas emojis: https://apps.timwhitlock.info/emoji/tables/unicode
            */
            /*
                Se puede utilizar un argumento como status, es decir, 
                    si el args contiene en el 3er 
                    argumento un 'OK' se concatena un ✅ al principio del mensaje. ej:
                        .\TelegramBotMessage.exe <token> <chatID> OK Los procesos etl han corrido satisfactoriamente 
                            "✅ Los procesos etl han corrido satisfactoriamente"
            */

            //Agregar estas dos lineas para evitar excepciones
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            if (args.Length >= 3)
            {
                string token = args[0]; // "1785746650:AAEhZGWi9EC4_oGxTJRHI9-XZEnYFO3dEpM";
                string chatID = args[1]; //"-345547283";
                string status = args[2];
                string mensaje = "";// = args[2];

                /*
                    El siguiente for se realiza ya que el mensaje viene separado por espacios, y C# entiende que son parametros distintos. 
                */
                for (int x = 2; x<args.Length; x ++)
                {
                    mensaje += args[x];
                    mensaje += " ";
                }

                string urlString = $"https://api.telegram.org/bot" + token + "/sendMessage?chat_id=" + chatID + "&text=" + mensaje ;
                WebClient webCliente = new WebClient();

                string a = webCliente.DownloadString(urlString);
            }
        }
    }
}

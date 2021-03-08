using System.Collections.Generic;

namespace ProjectVaka.Base
{
    public class Commands : Queue<Command>
    {
        /// <summary>
        /// Bu yapıının kurulmasının nedeni Mars a giden komutların uzun sürede vardığı varsayımıdır.
        /// Gezilecek alan ve robotun konumu belirlendikten sonra robotun gezeceği rota tek seferde girilirek tüm komutlar toplanır.
        /// Komutlar tammalandığında sırasıyla hızlıca çalıştırılır ve bu esnada robotun çektiği video çok kısa sürede istenilen bilgileri toplamış olur
        /// Diğer türlü her komutta kaybedilecek zaman zarfında çekilen görüntüler israf olacaktır.
        /// </summary>
        public void ExecuteCommands()
        {
            while (this.Count > 0)
                this.Dequeue().Execute();
        }
    }
}

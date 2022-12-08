using AdminPanel.EntityLayer.Abctract;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPanel.EntityLayer.Concrete.Base
{
    public class YbsFiloBase : IEntity
    {
        [Column("ID")]
        public int id { get; set; }
    }
}

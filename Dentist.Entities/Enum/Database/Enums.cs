using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Entities.Enum.Database
{
    public enum AuditStatus
    {
        created = 1,
        updated = 2,
        deleted = 3
    }
    public enum ProcessStatus
    {
        //pending = 1,
        //completed = 2,
        //Confirmation = 3,
        //GotoCargo = 4,
        //DeliverCargo = 5,
        //Deliver = 6
        unread = 1,
        read = 2
    }
    public enum TableType
    {
        Home = 1,
        About = 2,
        Contact = 3,
        WorkingHour = 4,
        Statistic = 5,
        Global = 6
    }
    public enum DataType
    {
        Article = 1,
        Service = 2
    }
    public enum AreaType
    {
        [Description("Karşılama Alanı")]
        Welcome = 1,
        [Description("Hakkımızda")]
        About = 2,
        [Description("Hizmetlerimiz")]
        Service = 3,
        [Description("Fiyatlandırma")]
        Pricing = 4,
        [Description("Randevu")]
        Appointment = 5,
        [Description("Kadromuz")]
        Employee = 6,
        [Description("Müşteri Yorumları")]
        Client = 7,
        [Description("Makaleler")]
        Article = 8,
        [Description("Üst Adres")]
        HeaderAddress = 9,
        [Description("Üst Mail")]
        HeaderMail = 10,
        [Description("Üst Sosyal Medya")]
        HeaderSocialMedia = 11,
        [Description("Alt İletişim")]
        FooterContact = 12,
        [Description("Alt Çalışma Saatleri")]
        FooterWorkingHour = 13,
        [Description("Alt Hızlı Ulaşın")]
        FooterQuickLink = 14,
        [Description("Alt Abonelik")]
        FooterNewsletter = 15,
        [Description("Alt Sosyal Medya")]
        FooterSocialMedia = 16
    }
}

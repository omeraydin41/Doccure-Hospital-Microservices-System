namespace Doccure.AppointmentService.Entities
{
    public class AppointmentDetail
    {
        public int AppointmentDetailId { get; set; }

        // Ana randevu tablosu ile ilişkiyi kuran Foreign Key (Yabancı Anahtar)
        public int AppointmentId { get; set; }

        // Randevunun şikayet detayı veya hastanın ön açıklaması
        public string Complaint { get; set; }

        // Doktorun muayene sonrası yazdığı tanı/teşhis bilgisi
        public string Diagnosis { get; set; }

        // Tedavi için yazılan reçete bilgisi veya notlar
        public string Prescription { get; set; }

        // Randevunun tamamlandığı tarih ve saat bilgisi
        public DateTime ComplatedDate { get; set; }

        // Ödeme yapıldı mı bilgisi
        public bool IsFirstVisit { get; set; }

        public Appointment Appointment { get; set; } // Navigation property to the Appointment entity

    }
}

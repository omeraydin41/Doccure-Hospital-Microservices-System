namespace Doccure.ReviewService.Dtos.ReviewDtos
{
    public class ResultReviewDto
    {
        public string ReviewId { get; set; }      // Değerlendirmenin (yorumun) benzersiz kimliği (Primary Key)
        public string DoctorId { get; set; }      // Yorumun hangi doktora yapıldığını belirten doktor kimliği (Foreign Key)
        public string UserName { get; set; }      // Yorumu yapan kullanıcının ekranda görünecek adı
        public string UserImageUrl { get; set; }  // Yorumu yapan kullanıcının profil resminin dosya/internet yolu (URL)
        public string Comment { get; set; }       // Kullanıcının yazdığı detaylı yorum metni
        public int Rating { get; set; }           // Kullanıcının doktora verdiği puan (örneğin 1 ile 5 arası)
        public bool Recommend { get; set; }       // Kullanıcının bu doktoru başkalarına tavsiye edip etmediği (True/False)
        public int LikeCount { get; set; }        // Bu yorumun diğer kullanıcılar tarafından kaç kez beğenildiği
        public DateTime CreatedDate { get; set; } // Yorumun sisteme kaydedildiği tam tarih ve saat
    }
}

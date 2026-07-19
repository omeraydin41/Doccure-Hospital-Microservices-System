namespace Doccure.PrescriptionService.Entities
{
    public class PrescriptionItem
    {
        public int PrescriptionItemId { get; set; }
        public string MedicineName { get; set; }
        public  string Usage { get; set; }//gunde kaç kez 
        public  string Duration { get; set; }//kaç gun kullanılacak 
        public Prescription Prescription { get; set; }//her ilacın sadece bir reçetesi vardır
    }
}

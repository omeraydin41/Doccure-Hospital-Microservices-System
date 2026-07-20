namespace Doccure.PrescriptionService.Dtos.PrescriptionDtos
{
    public class PrescriptionItemDto
    {
        public string MedicineName { get; set; }
        public string Usage { get; set; }//gunde kaç kez 
        public string Duration { get; set; }//kaç gun kullanılacak 
    }
    /* 
         JSON FORMATI (Item Objesi):
         {
           "medicineName": "Parol 500mg Tablet",
           "usage": "Günde 2 kez (Tok karnına)",
           "duration": "5 gün"
         }
         */
}

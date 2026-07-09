namespace Doccure.BranchService.Dtos.BranchDtos
{
    public class CreateBranchDto
    {
        // public string BranchId { get; set; } cerate kısmında ıd kendili oluşturulacak o yüzden create kısmında id yok
        public string BranchName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}

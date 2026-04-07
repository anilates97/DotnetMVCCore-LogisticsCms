using System.ComponentModel.DataAnnotations;

namespace LogisticsCMS.Dtos.Question
{
    public abstract class QuestionDtoBase
    {
        [Required(ErrorMessage = "Soru basligi zorunludur.")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Soru basligi 5 ile 200 karakter arasında olmalıdır.")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Soru açıklamasi zorunludur.")]
        [StringLength(2000, MinimumLength = 10, ErrorMessage = "Soru açıklamasi 10 ile 2000 karakter arasında olmalıdır.")]
        public string Description { get; set; } = null!;

        public bool Status { get; set; }
    }

    public abstract class QuestionWithIdDtoBase : QuestionDtoBase
    {
        public string QuestionId { get; set; } = null!;
    }
}

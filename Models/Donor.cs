using System.ComponentModel.DataAnnotations;

namespace DisasterResponseHub.Models
{
    public enum DonorType
    {
        Individual = 0,
        Company = 1,
        Organization = 2,
        Government = 3
    }

    public enum DonationCategory
    {
        Monetary = 0,
        Clothes = 1,
        Food = 2
    }

    public class GoodsDonated
    {
        [Key]
        public int GoodDonatedId { get; set; }

        [Required]
        public DateTime DateDonated { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public int NumberOfItems { get; set; }

        [Required]
        public DonationCategory DonationCategory { get; set; }

    }

    public class Donor
    {
        [Key]
        public Guid DonorID { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public DonorType DonorType { get; set; }

        [Required]
        public bool IsAnonymous { get; set; }

        public GoodsDonated GoodsDonated { get; set; }
    }
}

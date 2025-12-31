using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChessWebsite.Models
{
    public class TournamentViewModel
    {
        public int TournamentId { get; set; }

        [Required(ErrorMessage = "Tournament name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        [Display(Name = "Tournament Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Start date is required")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Start Date & Time")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required")]
        [DataType(DataType.DateTime)]
        [Display(Name = "End Date & Time")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Location is required")]
        [StringLength(100, ErrorMessage = "Location cannot be longer than 100 characters")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Max participants is required")]
        [Range(2, 1000, ErrorMessage = "Max participants must be between 2 and 1000")]
        [Display(Name = "Maximum Participants")]
        public int MaxParticipants { get; set; }

        [Required(ErrorMessage = "Entry fee is required")]
        [Range(0, 10000, ErrorMessage = "Entry fee must be between 0 and 10000")]
        [DataType(DataType.Currency)]
        [Display(Name = "Entry Fee")]
        public decimal EntryFee { get; set; }

        [Required(ErrorMessage = "Tournament type is required")]
        [Display(Name = "Tournament Type")]
        public TournamentType Type { get; set; }

        [Display(Name = "Time Control")]
        [StringLength(50, ErrorMessage = "Time control cannot be longer than 50 characters")]
        public string TimeControl { get; set; } = "90+30";

        // OPTION 1: Single total prize pool (Optional)
        [Display(Name = "Total Prize Pool")]
        [DataType(DataType.Currency)]
        public decimal? PrizePool { get; set; }

        // OPTION 2: Individual place prizes (all optional)
        [Display(Name = "1st Place Prize")]
        [DataType(DataType.Currency)]
        public decimal? FirstPlacePrize { get; set; }

        [Display(Name = "2nd Place Prize")]
        [DataType(DataType.Currency)]
        public decimal? SecondPlacePrize { get; set; }

        [Display(Name = "3rd Place Prize")]
        [DataType(DataType.Currency)]
        public decimal? ThirdPlacePrize { get; set; }

        [Display(Name = "4th Place Prize")]
        [DataType(DataType.Currency)]
        public decimal? FourthPlacePrize { get; set; }

        [Display(Name = "5th Place Prize")]
        [DataType(DataType.Currency)]
        public decimal? FifthPlacePrize { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [Display(Name = "Status")]
        public TournamentStatus Status { get; set; } = TournamentStatus.Upcoming;

        [Display(Name = "Registration Deadline")]
        [DataType(DataType.DateTime)]
        public DateTime? RegistrationDeadline { get; set; }

        [Display(Name = "Organizer Name")]
        [StringLength(100)]
        public string OrganizerName { get; set; }

        [Display(Name = "Contact Email")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string ContactEmail { get; set; }

        [Display(Name = "Rules")]
        [StringLength(2000)]
        public string Rules { get; set; }

        // Helper property to calculate total from individual prizes
        [NotMapped]
        public decimal IndividualPrizesTotal =>
            (FirstPlacePrize ?? 0) + (SecondPlacePrize ?? 0) + (ThirdPlacePrize ?? 0) +
            (FourthPlacePrize ?? 0) + (FifthPlacePrize ?? 0);

        [NotMapped]
        public bool HasIndividualPrizes =>
            (FirstPlacePrize.HasValue && FirstPlacePrize.Value > 0) ||
            (SecondPlacePrize.HasValue && SecondPlacePrize.Value > 0) ||
            (ThirdPlacePrize.HasValue && ThirdPlacePrize.Value > 0) ||
            (FourthPlacePrize.HasValue && FourthPlacePrize.Value > 0) ||
            (FifthPlacePrize.HasValue && FifthPlacePrize.Value > 0);
    }
}
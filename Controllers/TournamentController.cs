using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using System.Threading.Tasks;
using ChessWebsite.Data;
using ChessWebsite.Models;

namespace ChessWebsite.Controllers
{
    public class TournamentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TournamentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string search, string status, string type, int page = 1)
        {
            ViewBag.IsAdmin = User.IsInRole("Admin");
            ViewBag.IsLoggedIn = User.Identity?.IsAuthenticated ?? false;

            int pageSize = 9;

            IQueryable<Tournament> tournamentsQuery = _context.Tournaments
                .Where(t => t.IsActive);

            if (!string.IsNullOrEmpty(search))
            {
                tournamentsQuery = tournamentsQuery.Where(t =>
                    t.Name.Contains(search) ||
                    t.Description.Contains(search) ||
                    t.Location.Contains(search));
            }

            if (!string.IsNullOrEmpty(status) && Enum.TryParse<TournamentStatus>(status, out var statusEnum))
            {
                tournamentsQuery = tournamentsQuery.Where(t => t.Status == statusEnum);
            }

            if (!string.IsNullOrEmpty(type) && Enum.TryParse<TournamentType>(type, out var typeEnum))
            {
                tournamentsQuery = tournamentsQuery.Where(t => t.Type == typeEnum);
            }

            tournamentsQuery = tournamentsQuery.OrderBy(t => t.StartDate);

            var totalTournaments = await tournamentsQuery.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalTournaments / pageSize);

            var tournaments = await tournamentsQuery
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.Search = search;
            ViewBag.Status = status;
            ViewBag.Type = type;

            return View(tournaments);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournament = await _context.Tournaments
                .FirstOrDefaultAsync(m => m.TournamentId == id);

            if (tournament == null)
            {
                return NotFound();
            }

            ViewBag.IsAdmin = User.IsInRole("Admin");
            ViewBag.IsLoggedIn = User.Identity?.IsAuthenticated ?? false;
            ViewBag.CanEdit = CanEditTournament(tournament) && User.IsInRole("Admin");

            var relatedTournaments = await _context.Tournaments
                .Where(t => t.IsActive &&
                           t.TournamentId != id &&
                           t.Type == tournament.Type &&
                           t.Status == TournamentStatus.RegistrationOpen)
                .OrderBy(t => t.StartDate)
                .Take(3)
                .ToListAsync();

            ViewBag.RelatedTournaments = relatedTournaments;

            return View(tournament);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewBag.IsAdmin = true;
            ViewBag.IsLoggedIn = true;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(TournamentViewModel tournamentVM)
        {
            if (!User.IsInRole("Admin"))
            {
                TempData["ErrorMessage"] = "Admin access required to create tournaments.";
                return RedirectToAction("Index");
            }

            // Check if BOTH prize options are filled
            bool hasPrizePool = tournamentVM.PrizePool.HasValue && tournamentVM.PrizePool.Value > 0;
            bool hasIndividualPrizes = tournamentVM.HasIndividualPrizes;

            if (hasPrizePool && hasIndividualPrizes)
            {
                ModelState.AddModelError("PrizePool", "Please specify either a total prize pool OR individual place prizes, not both.");
            }

            // If neither prize option is filled, that's okay (no prizes)
            // Clear the error if only one or neither is filled
            if (!hasPrizePool && !hasIndividualPrizes)
            {
                // No prizes - that's acceptable
            }

            if (ModelState.IsValid)
            {
                var tournament = new Tournament
                {
                    Name = tournamentVM.Name,
                    Description = tournamentVM.Description,
                    StartDate = tournamentVM.StartDate,
                    EndDate = tournamentVM.EndDate,
                    Location = tournamentVM.Location,
                    MaxParticipants = tournamentVM.MaxParticipants,
                    EntryFee = tournamentVM.EntryFee,
                    Type = tournamentVM.Type,
                    TimeControl = tournamentVM.TimeControl,
                    PrizePool = tournamentVM.PrizePool,
                    FirstPlacePrize = tournamentVM.FirstPlacePrize,
                    SecondPlacePrize = tournamentVM.SecondPlacePrize,
                    ThirdPlacePrize = tournamentVM.ThirdPlacePrize,
                    FourthPlacePrize = tournamentVM.FourthPlacePrize,
                    FifthPlacePrize = tournamentVM.FifthPlacePrize,
                    Status = tournamentVM.Status,
                    RegistrationDeadline = tournamentVM.RegistrationDeadline,
                    OrganizerName = tournamentVM.OrganizerName,
                    ContactEmail = tournamentVM.ContactEmail,
                    Rules = tournamentVM.Rules,
                    CreatedDate = DateTime.Now,
                    LastUpdated = DateTime.Now,
                    IsActive = true
                };

                _context.Add(tournament);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Tournament created successfully!";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.IsAdmin = true;
            ViewBag.IsLoggedIn = true;
            return View(tournamentVM);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (!User.IsInRole("Admin"))
            {
                TempData["ErrorMessage"] = "Admin access required to edit tournaments.";
                return RedirectToAction("Details", new { id });
            }

            if (id == null)
            {
                return NotFound();
            }

            var tournament = await _context.Tournaments.FindAsync(id);
            if (tournament == null)
            {
                return NotFound();
            }

            if (!CanEditTournament(tournament))
            {
                TempData["ErrorMessage"] = "Cannot edit tournament after registration deadline has passed.";
                return RedirectToAction(nameof(Details), new { id });
            }

            var tournamentVM = new TournamentViewModel
            {
                TournamentId = tournament.TournamentId,
                Name = tournament.Name,
                Description = tournament.Description,
                StartDate = tournament.StartDate,
                EndDate = tournament.EndDate,
                Location = tournament.Location,
                MaxParticipants = tournament.MaxParticipants,
                EntryFee = tournament.EntryFee,
                Type = tournament.Type,
                TimeControl = tournament.TimeControl,
                PrizePool = tournament.PrizePool,
                FirstPlacePrize = tournament.FirstPlacePrize,
                SecondPlacePrize = tournament.SecondPlacePrize,
                ThirdPlacePrize = tournament.ThirdPlacePrize,
                FourthPlacePrize = tournament.FourthPlacePrize,
                FifthPlacePrize = tournament.FifthPlacePrize,
                Status = tournament.Status,
                RegistrationDeadline = tournament.RegistrationDeadline,
                OrganizerName = tournament.OrganizerName,
                ContactEmail = tournament.ContactEmail,
                Rules = tournament.Rules
            };

            ViewBag.IsAdmin = true;
            ViewBag.IsLoggedIn = true;
            return View(tournamentVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, TournamentViewModel tournamentVM)
        {
            if (!User.IsInRole("Admin"))
            {
                TempData["ErrorMessage"] = "Admin access required to edit tournaments.";
                return RedirectToAction("Details", new { id });
            }

            if (id != tournamentVM.TournamentId)
            {
                return NotFound();
            }

            var tournament = await _context.Tournaments.FindAsync(id);
            if (tournament == null)
            {
                return NotFound();
            }

            if (!CanEditTournament(tournament))
            {
                TempData["ErrorMessage"] = "Cannot edit tournament after registration deadline has passed.";
                return RedirectToAction(nameof(Details), new { id });
            }

            // Check if BOTH prize options are filled
            bool hasPrizePool = tournamentVM.PrizePool.HasValue && tournamentVM.PrizePool.Value > 0;
            bool hasIndividualPrizes = tournamentVM.HasIndividualPrizes;

            if (hasPrizePool && hasIndividualPrizes)
            {
                ModelState.AddModelError("PrizePool", "Please specify either a total prize pool OR individual place prizes, not both.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    tournament.Name = tournamentVM.Name;
                    tournament.Description = tournamentVM.Description;
                    tournament.StartDate = tournamentVM.StartDate;
                    tournament.EndDate = tournamentVM.EndDate;
                    tournament.Location = tournamentVM.Location;
                    tournament.MaxParticipants = tournamentVM.MaxParticipants;
                    tournament.EntryFee = tournamentVM.EntryFee;
                    tournament.Type = tournamentVM.Type;
                    tournament.TimeControl = tournamentVM.TimeControl;
                    tournament.PrizePool = tournamentVM.PrizePool;
                    tournament.FirstPlacePrize = tournamentVM.FirstPlacePrize;
                    tournament.SecondPlacePrize = tournamentVM.SecondPlacePrize;
                    tournament.ThirdPlacePrize = tournamentVM.ThirdPlacePrize;
                    tournament.FourthPlacePrize = tournamentVM.FourthPlacePrize;
                    tournament.FifthPlacePrize = tournamentVM.FifthPlacePrize;
                    tournament.Status = tournamentVM.Status;
                    tournament.RegistrationDeadline = tournamentVM.RegistrationDeadline;
                    tournament.OrganizerName = tournamentVM.OrganizerName;
                    tournament.ContactEmail = tournamentVM.ContactEmail;
                    tournament.Rules = tournamentVM.Rules;
                    tournament.LastUpdated = DateTime.Now;

                    _context.Update(tournament);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Tournament updated successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TournamentExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), new { id });
            }

            ViewBag.IsAdmin = true;
            ViewBag.IsLoggedIn = true;
            return View(tournamentVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!User.IsInRole("Admin"))
            {
                TempData["ErrorMessage"] = "Admin access required to delete tournaments.";
                return RedirectToAction("Details", new { id });
            }

            var tournament = await _context.Tournaments.FindAsync(id);
            if (tournament != null)
            {
                if (!CanEditTournament(tournament))
                {
                    TempData["ErrorMessage"] = "Cannot delete tournament after registration deadline has passed.";
                    return RedirectToAction(nameof(Details), new { id });
                }

                tournament.IsActive = false;
                tournament.LastUpdated = DateTime.Now;
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Tournament deleted successfully!";
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(int id)
        {
            var tournament = await _context.Tournaments.FindAsync(id);
            if (tournament == null)
            {
                return NotFound();
            }

            if (tournament.CurrentParticipants >= tournament.MaxParticipants)
            {
                TempData["ErrorMessage"] = "Tournament is full!";
                return RedirectToAction(nameof(Details), new { id });
            }

            tournament.CurrentParticipants++;
            tournament.LastUpdated = DateTime.Now;
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Successfully registered for the tournament!";
            return RedirectToAction(nameof(Details), new { id });
        }

        private bool TournamentExists(int id)
        {
            return _context.Tournaments.Any(e => e.TournamentId == id);
        }

        private bool CanEditTournament(Tournament tournament)
        {
            if (!User.IsInRole("Admin")) return false;

            if (tournament.RegistrationDeadline.HasValue)
            {
                return DateTime.Now <= tournament.RegistrationDeadline.Value;
            }

            return DateTime.Now <= tournament.StartDate;
        }
    }
}
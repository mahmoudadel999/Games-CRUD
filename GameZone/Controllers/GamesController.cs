﻿using Microsoft.AspNetCore.Mvc;

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly ICategoriesService _categoriesService;
        private readonly IDevicesService _devicesService;
        private readonly IGamesService _gamesService;

        public GamesController(
            AppDbContext dbContext,
            ICategoriesService categoriesService,
            IDevicesService devicesService,
            IGamesService gamesService)
        {
            _dbContext = dbContext;
            _categoriesService = categoriesService;
            _devicesService = devicesService;
            _gamesService = gamesService;
        }

        public IActionResult Index()
        {
            var games = _gamesService.GetAllGames();
            return View(games);
        }

        public IActionResult Details(int id)
        {
            var game = _gamesService.GetById(id);

            if (game is null)
                return NotFound();

            return View(game);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateGameFormViewModel viewModel = new()
            {
                Categories = _categoriesService.GetSelectList(),
                Devices = _devicesService.GetSelectList(),
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoriesService.GetSelectList();
                model.Devices = _devicesService.GetSelectList();

                return View(model);
            }


            await _gamesService.Create(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var game = _gamesService.GetById(id);

            if (game is null)
                return NotFound();

            EditGameFormViewModel viewModel = new()
            {
                Id = id,
                Name = game.Name,
                Description = game.Description,
                CategoryId = game.CategoryId,
                SelectedDevices = game.Devices.Select(GD => GD.DeviceId).ToList(),
                Categories = _categoriesService.GetSelectList(),
                Devices = _devicesService.GetSelectList(),
                CurrentCover = game.Cover,
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditGameFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoriesService.GetSelectList();
                model.Devices = _devicesService.GetSelectList();
                return View(model);
            }

            var game = await _gamesService.Update(model);

            if (game is null)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var isDeleted = _gamesService.Delete(id);
            if (!isDeleted)
                return BadRequest();

            return Ok();
        }

    }
}

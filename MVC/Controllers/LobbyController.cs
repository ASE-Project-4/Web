﻿using System;
using System.Web.Mvc;
using Common;
using Common.Models;
using MVC.Identity;
using MVC.ViewModels;

namespace MVC.Controllers
{
    [Authorize]
    public class LobbyController : Controller
    {
        private IFactory _factory;
        private IUserContext _userContext;

        public LobbyController(IFactory factory, IUserContext userContext)
        {
            _factory = factory;
            _userContext = userContext;
        }

        // GET: /<controller>/
        public ActionResult Index()
        {
            return View();
        }

        // GET: /<controller>/Create
        public ActionResult Create()
        {
            return View(new CreateLobbyViewModel());
        }

        [HttpPost]
        // POST: /<controller>/Create
        public ActionResult Create(CreateLobbyViewModel viewModel)
        {
            using (var myWork = _factory.GetUOF())
            {
                // Perform data validation.
                if (!TryValidateModel(viewModel))
                {
                    // Errors, return and let the user handle it.
                    return View(viewModel);
                }

                // Create the domain lobby object.
                var lobby = new Lobby()
                {
                    Name = viewModel.Name,
                    Description = viewModel.Description,
                };

                // Save to the database.
                myWork.Lobby.Add(lobby);
                var aUser = myWork.User.Get(_userContext.Identity.Name);
                lobby.MemberList.Add(aUser);
                myWork.Complete();

                // Show the newly created lobby.
                return Redirect($"/Lobby/Show/{lobby.LobbyId}");
            }

            //TODO: Return error.
        }

        // GET: /<controller>/List
        public ActionResult List()
        {
            using (var myWork = _factory.GetUOF())
            {
                // Get all lobbies, and convert to the domain model.
                var hej = User.Identity.Name;
                ;

                var aUser = myWork.User.Get(_userContext.Identity.Name);

                // Display the lobbies.
                var viewModel = new LobbiesViewModel()
                {
                    MemberOfLobbies = aUser.MemberOfLobbies
                };

                return View(viewModel);
            }   
        }

        // GET: /<controller>/Show/<id>
        public ActionResult Show(long id)
        {
            using (var myWork = _factory.GetUOF())
            {
                // Get the lobby from the database.
                var lobby = myWork.Lobby.Get(id);

                if (lobby == null)
                {
                    // Error.
                    throw new Exception("No such lobby");
                }

                // Create a viewmodel for the lobby.
                var viewModel = new LobbyViewModel()
                {
                    ID = lobby.LobbyId,
                    Name = lobby.Name,
                    Description = lobby.Description,
                    Bets = lobby.Bets
                };

                return View(viewModel);
            }
        }
    }
}

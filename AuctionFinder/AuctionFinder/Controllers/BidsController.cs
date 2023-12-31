﻿using AuctionFinder.Auth.Model;
using AuctionFinder.Data.Dtos.Auctions;
using AuctionFinder.Data.Dtos.Bids;
using AuctionFinder.Data.Dtos.Categories;
using AuctionFinder.Data.Entities;
using AuctionFinder.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace AuctionFinder.Controllers
{
    [ApiController]
    [Route("api/categories/{categoryId}/auctions/{auctionId}/bids")]
    public class BidsController : Controller
    {
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IAuctionsRepository _auctionsRepository;
        private readonly IBidsRepository _bidsRepository;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<AuctionFinderUser> _userManager;

        public BidsController(UserManager<AuctionFinderUser> userManager, ICategoriesRepository categoriesRepository, IAuctionsRepository auctionsRepository, IBidsRepository bidsRepository, IAuthorizationService authorizationService)
        {
            _categoriesRepository = categoriesRepository;
            _auctionsRepository = auctionsRepository;
            _bidsRepository = bidsRepository;
            _authorizationService = authorizationService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetBidDto>>> GetMany(int categoryId, int auctionId)
        {
            var category = await _categoriesRepository.GetSingleAsync(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            var auctions = await _auctionsRepository.GetManyAsync();

            var currentAuctions = auctions.Where(entity => entity.Category == category)
                .Select(entity => new AuctionDto(entity.Id, entity.Name, entity.Description, entity.StartDate,
                entity.EndDate, entity.Category, entity.UserId)).ToList();

            var auction = await _auctionsRepository.GetSingleAsync(auctionId);

            if (auction == null)
            {
                return NotFound();
            }

            var currentAuctionContainment = currentAuctions.Where(entity => entity.Id == auction.Id).FirstOrDefault();

            if (currentAuctionContainment == null)
            {
                return NotFound();
            }

            var bids = await _bidsRepository.GetManyAsync();
            List<FinalBid> finalBids = new List<FinalBid>();

            foreach (var bid in bids)
            {
                var user = await _userManager.FindByIdAsync(bid.UserId);

                FinalBid finalBid = new FinalBid();
                finalBid.Id = bid.Id;
                finalBid.BidSize = bid.BidSize;
                finalBid.Comment = bid.Comment;
                finalBid.CreationDate = bid.CreationDate;
                finalBid.Auction = bid.Auction;
                finalBid.UserId = bid.UserId;
                finalBid.UserEmail = user.Email;

                finalBids.Add(finalBid);
            }


            return finalBids.Where(entity => entity.Auction == auction).Select(entity => new GetBidDto(entity.Id, entity.BidSize, entity.Comment, entity.CreationDate,
                entity.Auction, entity.UserId, entity.UserEmail)).ToList();
        }

        [HttpGet]
        [Route("{bidId}"), ActionName("GetBid")]
        public async Task<ActionResult<GetBidDto>> GetSingle(int categoryId, int auctionId, int bidId)
        {
            var category = await _categoriesRepository.GetSingleAsync(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            var auctions = await _auctionsRepository.GetManyAsync();

            var currentAuctions = auctions.Where(entity => entity.Category == category)
                .Select(entity => new AuctionDto(entity.Id, entity.Name, entity.Description, entity.StartDate,
                entity.EndDate, entity.Category, entity.UserId)).ToList();

            var auction = await _auctionsRepository.GetSingleAsync(auctionId);

            if (auction == null)
            {
                return NotFound();
            }

            var currentAuctionContainment = currentAuctions.Where(entity => entity.Id == auction.Id).FirstOrDefault();

            if (currentAuctionContainment == null)
            {
                return NotFound();
            }

            var bids = await _bidsRepository.GetManyAsync();

            var currentPostBids = bids.Where(entity => entity.Auction == auction)
                .Select(entity => new BidDto(entity.Id, entity.BidSize, entity.Comment, entity.CreationDate,
                entity.Auction, entity.UserId)).ToList();

            var bid = await _bidsRepository.GetSingleAsync(bidId);

            if (bid == null)
            {
                return NotFound();
            }

            var currentBidContainment = currentPostBids.Where(entity => entity.Id == bid.Id).FirstOrDefault();

            if (currentBidContainment == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(bid.UserId);

            return new GetBidDto(bid.Id, bid.BidSize, bid.Comment, bid.CreationDate, bid.Auction, bid.UserId, user.Email);
        }

        [HttpPost]
        [Authorize(Roles = AuctionFinderRoles.AuctionUser)]
        public async Task<ActionResult<BidDto>> Create(int categoryId, int auctionId, CreateBidDto createBidDto)
        {
            var category = await _categoriesRepository.GetSingleAsync(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            var auctions = await _auctionsRepository.GetManyAsync();

            var currentAuctions = auctions.Where(entity => entity.Category == category)
                .Select(entity => new AuctionDto(entity.Id, entity.Name, entity.Description, entity.StartDate,
                entity.EndDate, entity.Category, entity.UserId)).ToList();

            var auction = await _auctionsRepository.GetSingleAsync(auctionId);

            if (auction == null)
            {
                return NotFound();
            }

            var currentAuctionContainment = currentAuctions.Where(entity => entity.Id == auction.Id).FirstOrDefault();

            if (currentAuctionContainment == null)
            {
                return NotFound();
            }

            var bids = await _bidsRepository.GetManyAsync();

            var currentPostBids = bids.Where(entity => entity.Auction == auction)
                .Select(entity => new BidDto(entity.Id, entity.BidSize, entity.Comment, entity.CreationDate,
                entity.Auction, entity.UserId)).ToList();


            if (createBidDto.BidSize == 0)
            {
                return UnprocessableEntity();
            }

            if (string.IsNullOrWhiteSpace(createBidDto.Comment))
            {
                return UnprocessableEntity();
            }

            if (createBidDto.Comment.Length < 2 || createBidDto.Comment.Length > 500)
            {
                return UnprocessableEntity();
            }

            if (createBidDto.CreationDate <= auction.StartDate || createBidDto.CreationDate >= auction.EndDate)
            {
                return UnprocessableEntity();
            }

            if (currentPostBids.Count != 0)
            {
                var mostRecetTime = currentPostBids.Max(enitity => enitity.CreationDate);

                if (createBidDto.CreationDate <= mostRecetTime)
                {
                    return UnprocessableEntity();
                }

                var highestBid = currentPostBids.Max(enitity => enitity.BidSize);

                if (createBidDto.BidSize <= highestBid)
                {
                    return UnprocessableEntity();
                }
            }

            var bid = new Bid
            {
                BidSize = createBidDto.BidSize,
                Comment = createBidDto.Comment,
                CreationDate = createBidDto.CreationDate,
                Auction = auction,
                UserId = User.FindFirstValue(JwtRegisteredClaimNames.Sub)
            };

            await _bidsRepository.CreateAsync(bid);

            return CreatedAtAction("GetBid", new { categoryId = category.Id, auctionId = auction.Id, bidId = bid.Id },
                new BidDto(bid.Id, bid.BidSize, bid.Comment, bid.CreationDate, bid.Auction, bid.UserId));
        }

        [HttpPut]
        [Route("{bidId}")]
        [Authorize(Roles = AuctionFinderRoles.AuctionUser)]
        public async Task<ActionResult<BidDto>> Update(int categoryId, int auctionId, int bidId, UpdateBidDto updateBidDto)
        {
            var category = await _categoriesRepository.GetSingleAsync(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            var auctions = await _auctionsRepository.GetManyAsync();

            var currentAuctions = auctions.Where(entity => entity.Category == category)
                .Select(entity => new AuctionDto(entity.Id, entity.Name, entity.Description, entity.StartDate,
                entity.EndDate, entity.Category, entity.UserId)).ToList();

            var auction = await _auctionsRepository.GetSingleAsync(auctionId);

            if (auction == null)
            {
                return NotFound();
            }

            var currentAuctionContainment = currentAuctions.Where(entity => entity.Id == auction.Id).FirstOrDefault();

            if (currentAuctionContainment == null)
            {
                return NotFound();
            }

            var bids = await _bidsRepository.GetManyAsync();

            var currentPostBids = bids.Where(entity => entity.Auction == auction)
                .Select(entity => new BidDto(entity.Id, entity.BidSize, entity.Comment, entity.CreationDate,
                entity.Auction, entity.UserId)).ToList();

            var bid = await _bidsRepository.GetSingleAsync(bidId);

            if (bid == null)
            {
                return NotFound();
            }

            var currentBidContainment = currentPostBids.Where(entity => entity.Id == bid.Id).FirstOrDefault();

            if (currentBidContainment == null)
            {
                return NotFound();
            }

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, bid, PolicyNames.ResourceOwner);
            if (!authorizationResult.Succeeded)
            {
                return Forbid();
            }

            if (string.IsNullOrWhiteSpace(updateBidDto.Comment))
            {
                return UnprocessableEntity();
            }

            if (updateBidDto.Comment.Length < 2 || updateBidDto.Comment.Length > 500)
            {
                return UnprocessableEntity();
            }

            bid.Comment = updateBidDto.Comment;
            await _bidsRepository.UpdateAsync(bid);

            return Ok(new BidDto(bid.Id, bid.BidSize, bid.Comment, bid.CreationDate, bid.Auction, bid.UserId));
        }

        [HttpDelete]
        [Route("{bidId}")]
        [Authorize(Roles = AuctionFinderRoles.AuctionUser)]
        public async Task<ActionResult> Remove(int categoryId, int auctionId, int bidId)
        {
            var category = await _categoriesRepository.GetSingleAsync(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            var auctions = await _auctionsRepository.GetManyAsync();

            var currentAuctions = auctions.Where(entity => entity.Category == category)
                .Select(entity => new AuctionDto(entity.Id, entity.Name, entity.Description, entity.StartDate,
                entity.EndDate, entity.Category, entity.UserId)).ToList();

            var auction = await _auctionsRepository.GetSingleAsync(auctionId);

            if (auction == null)
            {
                return NotFound();
            }

            var currentAuctionContainment = currentAuctions.Where(entity => entity.Id == auction.Id).FirstOrDefault();

            if (currentAuctionContainment == null)
            {
                return NotFound();
            }

            var bids = await _bidsRepository.GetManyAsync();

            var currentPostBids = bids.Where(entity => entity.Auction == auction)
                .Select(entity => new BidDto(entity.Id, entity.BidSize, entity.Comment, entity.CreationDate,
                entity.Auction, entity.UserId)).ToList();

            var bid = await _bidsRepository.GetSingleAsync(bidId);

            if (bid == null)
            {
                return NotFound();
            }

            var currentBidContainment = currentPostBids.Where(entity => entity.Id == bid.Id).FirstOrDefault();

            if (currentBidContainment == null)
            {
                return NotFound();
            }

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, bid, PolicyNames.ResourceOwner);
            if (!authorizationResult.Succeeded)
            {
                return Forbid();
            }

            await _bidsRepository.DeleteAsync(bid);

            return NoContent();
        }
    }
}
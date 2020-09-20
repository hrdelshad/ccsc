﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.Requests;

namespace ccsc.Web.Controllers
{
    public class RequestsController : Controller
    {
        private readonly CcscContext _context;

        public RequestsController(CcscContext context)
        {
            _context = context;
        }

        // GET: Requests
        public async Task<IActionResult> Index()
        {
            var ccscContext = _context.Requests.Include(r => r.Contact).Include(r => r.Product).Include(r => r.RequestChanel).Include(r => r.RequestStatus).Include(r => r.RequestType);
            return View(await ccscContext.ToListAsync());
        }

        // GET: Requests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .Include(r => r.Contact)
                .Include(r => r.Product)
                .Include(r => r.RequestChanel)
                .Include(r => r.RequestStatus)
                .Include(r => r.RequestType)
                .FirstOrDefaultAsync(m => m.RequestId == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // GET: Requests/Create
        public IActionResult Create()
        {
            ViewData["ContactId"] = new SelectList(_context.Contacts, "ContactId", "Email");
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Title");
            ViewData["RequestChanelId"] = new SelectList(_context.RequestChanels, "RequestChanelId", "Title");
            ViewData["RequestStatusId"] = new SelectList(_context.RequestStatuses, "RequestStatusId", "Title");
            ViewData["RequestTypeId"] = new SelectList(_context.RequestTypes, "RequestTypeId", "Title");
            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequestId,ContactId,RequestTime,RequestChanelId,RequestTypeId,ProductId,RequestStatusId,Content")] Request request)
        {
            if (ModelState.IsValid)
            {
                _context.Add(request);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContactId"] = new SelectList(_context.Contacts, "ContactId", "Email", request.ContactId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Title", request.ProductId);
            ViewData["RequestChanelId"] = new SelectList(_context.RequestChanels, "RequestChanelId", "Title", request.RequestChanelId);
            ViewData["RequestStatusId"] = new SelectList(_context.RequestStatuses, "RequestStatusId", "Title", request.RequestStatusId);
            ViewData["RequestTypeId"] = new SelectList(_context.RequestTypes, "RequestTypeId", "Title", request.RequestTypeId);
            return View(request);
        }

        // GET: Requests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }
            ViewData["ContactId"] = new SelectList(_context.Contacts, "ContactId", "Email", request.ContactId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Title", request.ProductId);
            ViewData["RequestChanelId"] = new SelectList(_context.RequestChanels, "RequestChanelId", "Title", request.RequestChanelId);
            ViewData["RequestStatusId"] = new SelectList(_context.RequestStatuses, "RequestStatusId", "Title", request.RequestStatusId);
            ViewData["RequestTypeId"] = new SelectList(_context.RequestTypes, "RequestTypeId", "Title", request.RequestTypeId);
            return View(request);
        }

        // POST: Requests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequestId,ContactId,RequestTime,RequestChanelId,RequestTypeId,ProductId,RequestStatusId,Content")] Request request)
        {
            if (id != request.RequestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(request);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestExists(request.RequestId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContactId"] = new SelectList(_context.Contacts, "ContactId", "Email", request.ContactId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Title", request.ProductId);
            ViewData["RequestChanelId"] = new SelectList(_context.RequestChanels, "RequestChanelId", "Title", request.RequestChanelId);
            ViewData["RequestStatusId"] = new SelectList(_context.RequestStatuses, "RequestStatusId", "Title", request.RequestStatusId);
            ViewData["RequestTypeId"] = new SelectList(_context.RequestTypes, "RequestTypeId", "Title", request.RequestTypeId);
            return View(request);
        }

        // GET: Requests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .Include(r => r.Contact)
                .Include(r => r.Product)
                .Include(r => r.RequestChanel)
                .Include(r => r.RequestStatus)
                .Include(r => r.RequestType)
                .FirstOrDefaultAsync(m => m.RequestId == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // POST: Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestExists(int id)
        {
            return _context.Requests.Any(e => e.RequestId == id);
        }
    }
}

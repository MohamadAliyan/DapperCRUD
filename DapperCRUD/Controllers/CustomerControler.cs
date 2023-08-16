using DapperCRUD.Models;
using DapperCRUD.Repository.Interface;
using DapperCRUD.Repository.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DapperCRUD.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerRepository _customerRepository;
        private IAddressRepository _AddressRepository;
        public CustomerController(ICustomerRepository customerRepository, IAddressRepository addressRepository)
        {
            _customerRepository = customerRepository;
            _AddressRepository = addressRepository;
        }

        public async Task<IActionResult> Index()
        {
            List<Customer> result = await _customerRepository.GetAllAsync();
            return View(result);
        }
        public async Task<IActionResult> Addresses(int id)
        {
            var result = await _customerRepository.GetById(id);
            return View(result);
        }
        public async Task<IActionResult> AddAddresses(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAddresses(CreatedAddressDTO address)
        {
            if (ModelState.IsValid)
            {

                await _AddressRepository.Create(address);
                return RedirectToAction(nameof(Index));
            }
            return View(address.CustomerId);
        }
        [HttpDelete, ActionName("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(int id) { 

            return RedirectToAction("Index");
        }
        [HttpDelete, ActionName("DeleteAddress")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            await _AddressRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

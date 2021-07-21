using System;

namespace url.business.Models
{
    public class UserBaseReduceViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool FirstAccess { get; set; }
        public string Photograph { get; set; }
        public string PhotographUpload { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public string Complement { get; set; }
        public Guid NeighborhoodId { get; set; }
        public string ZipCode { get; set; }
        public string LocalToken { get; set; }
    }
}
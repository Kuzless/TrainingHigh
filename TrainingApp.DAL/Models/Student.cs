namespace Training__DAL_.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}

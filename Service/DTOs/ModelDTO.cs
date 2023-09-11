namespace Service.DTOs
{
    public class ModelDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ModelDTO() { }

        public ModelDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}

namespace Task7.Services
{
    public interface IGetStudentInfoService
    {
        public Task<string> GetInfo(int id); 
        void SetFormatter(IInfoStringFormatter formatter);
    }
}

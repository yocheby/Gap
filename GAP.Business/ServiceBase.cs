namespace GAP.Business
{
    using GAP.Business.Global;
    using GAP.Data.Model;

    public class ServiceBase
    {
        public GAP_DBEntities _db { get; set; }

        public ServiceBase()
        {
            InitConnection((int)DataBaseEngine.SqlServer);
        }

        private void InitConnection(int dbEngine)
        {
            switch (dbEngine)
            {
                case (int)DataBaseEngine.SqlServer:
                    _db = new GAP_DBEntities();
                    break;
            }
        }
    }
}

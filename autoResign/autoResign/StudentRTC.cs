namespace autoResign
{
    public class StudentRTC : powerSchoolForm
    {
        public StudentRTC(string uName, string uPass)
            :base (uName, uPass)
        {
            InitializeComponent();
            base.initChrome();
            base.loadJS();
            base.loadCheckJS();
        }
    }
}
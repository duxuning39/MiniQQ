using MiniQQLib;
using MiniQQServer;

namespace MiniQQ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            test();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TCPServerManager.Instance.OpenServer(19521);
            button1.Enabled = false;
            TCPServerManager.Instance.RecRegisterReqAction = UserRegister;


        }

        public void UserRegister(RegisterReq registerReq,string ip)
        {
            //if (getUserByName(registerReq.Username)!=null)
            //{

            //}
            RegisterRsp registerRsp = new RegisterRsp();
            registerRsp.Username = registerReq.Username;
            registerRsp.Result = true;


            TCPServerManager.Instance.SendObjectByIP(ip, registerRsp, MsgType.MSG_TYPE_REGISTER_RSP);
        }

        public Userinfo? getUserByName(string Username)
        {
            List<Userinfo> allUsers = getAllUsers();
            return allUsers.Find((u)=>u.Username==Username);
        }

        public List<Userinfo> getAllUsers()
        {
            UserInfomations info = (UserInfomations)MyTools.DeserializeFromFile("1.data");
            return info.MyUserInfos;
        }

        public void test()
        {
            UserInfomations u = new UserInfomations();
            Userinfo u1 =new Userinfo();
            u1.Username = "username";
            u1.Password = "password";

            FriendInfo f1 = new FriendInfo();
            f1.FriendName = "1";
            f1.FriendNickName = "2";

            FriendInfo f2 = new FriendInfo();
            f2.FriendName = "3";
            f2.FriendNickName = "4";

            u1.FriendInfos.Add(f1);
            u1.FriendInfos.Add(f2);

            u.MyUserInfos.Add(u1);



            Userinfo u2 = new Userinfo();
            u2.Username = "username"; 
            u2.Password = "password";

            FriendInfo f3 = new FriendInfo();
            f3.FriendName = "11";
            f3.FriendNickName = "21";

            FriendInfo f4 = new FriendInfo();
            f4.FriendName = "31";
            f4.FriendNickName = "41";

            u2.FriendInfos.Add(f3);
            u2.FriendInfos.Add(f4);

            u.MyUserInfos.Add(u2);


            MyTools.Serialize2Fill("1.data", u);


            UserInfomations newU = (UserInfomations)MyTools.DeserializeFromFile("1.data");
        }
    }
}
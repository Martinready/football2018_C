using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _01football.Models;

namespace _01football.Controllers
{
    public class HomeController : Controller
    {
        shoppingEntities shopping = new shoppingEntities();
        demoEntities2 db = new demoEntities2();
        // GET: Home
        public ActionResult Index()
        {
            if (Session["member"] == null)
            {
                return View("Index", "_Layout");
            }
            return View("Index", "_Layoutmember");

        }

        public ActionResult Soccer()
        {
            var query = from o in db.teams
                        select o;
            List<team> empList = query.ToList();
            return View(empList);
        }

        public ActionResult Bar(int? id)
        {
            var query = from o in db.teams
                        where o.id == id
                        select o;
            team emp = query.Single();
            return View(emp);

        }

        [HttpPost]
        public ActionResult Bar()
        {
            if (Request.Form["btnOKCancel"] == "Cancel")
            {
                return RedirectToAction("Soccer");
            }

            return RedirectToAction("Soccer");
        }

        public ActionResult game()
        {
            var query = from o in db.contacts
                        select o;
            List<contact> empList = query.ToList();
            return View(empList);

        }
        [HttpPost]
        public ActionResult game(string idd2)
        {

            var query = db.contacts.Where(m => m.country1 == idd2).FirstOrDefault();
            if (query == null)
            {
                ViewBag.Message = "???";
                return View();
            }
            return Redirect("/Home/Contact/" + query.Id);
        }

        public ActionResult Contact(int? id)
        {
            //var test = country;
            var query = from w in db.contacts
                        where w.Id == id
                        select w;
            contact emp = query.Single();
            return View(emp);

        }

        [HttpPost]
        public ActionResult Contact()
        {
            if (Request.Form["btnOKCancel"] == "Cancel")
            {
                return RedirectToAction("game");
            }
 

            return RedirectToAction("game");
        }

        public ActionResult Sand()
        {
            var query = from o in db.teams
                        select o;
            List<team> empList = query.ToList();
            return View(empList);

        }

        [HttpPost]
        public ActionResult Sand(string dd2, string dd3)
        {

            var member = db.teams
                .Where(m => m.couuntry == dd2)
                .FirstOrDefault();

            var player = db.teams
                .Where(m => m.couuntry == dd3)
                .FirstOrDefault();
            if (member == null || player == null)
            {
                ViewBag.Message3 = "隊伍這屆未參加";
                return View();
            }
            if (member == player)
            {
                ViewBag.Message3 = "相同隊伍請重選";
                return View();
            }
            else if (member != player)
            {
                Random Rnd = new Random();

                int x1 = Rnd.Next(0, int.Parse(member.win));
                int x2 = Rnd.Next(0, int.Parse(member.flat));
                int GPx = int.Parse(member.GP);
                int x3 = Rnd.Next(0, int.Parse(member.GD));
                int x5 = Rnd.Next(0, int.Parse(member.score2));

                int y1 = Rnd.Next(0, int.Parse(player.win));
                int y2 = Rnd.Next(0, int.Parse(player.flat));
                int GPy = int.Parse(player.GP);
                int y3 = Rnd.Next(0, int.Parse(player.GD));
                int y5 = Rnd.Next(0, int.Parse(player.score2));


                int totalx = (x1 * 5 + x2 * 2 + x3 * 2 + x5 * 3 + GPx * 2) / 5;

                int totaly = (y1 * 5 + y2 * 2 + y3 * 2 + y5 * 3 + GPy * 2) / 5;


                if (totalx > totaly)
                {
                    ViewBag.image1 = member.src;
                    ViewBag.image2 = player.src;

                    ViewBag.Message1 = member.couuntry + ":" + Convert.ToInt32(totalx);
                    ViewBag.Message2 = player.couuntry + ":" + Convert.ToInt32(totaly);
                    ViewBag.Message3 = member.couuntry + "win" + " " + player.couuntry + "lose";
                }
                else if (totalx == totaly)
                {
                    ViewBag.image1 = member.src;
                    ViewBag.image2 = player.src;

                    ViewBag.Message1 = member.couuntry + ":" + Convert.ToInt32(totalx);
                    ViewBag.Message2 = player.couuntry + ":" + Convert.ToInt32(totaly);
                    ViewBag.Message3 = member.couuntry +" "+ player.couuntry + "平手";
                }
                else if (totalx < totaly)
                {
                    ViewBag.image1 = member.src;
                    ViewBag.image2 = player.src;

                    ViewBag.Message1 = member.couuntry + ":" + Convert.ToInt32(totalx);
                    ViewBag.Message2 = player.couuntry + ":" + Convert.ToInt32(totaly);
                    ViewBag.Message3 = member.couuntry + "lose" +" "+ player.couuntry + "win";
                }
                return View();

            }
            return View();
        }

        public ActionResult Shopping()
        {
            var product = shopping.tproducts.ToList();
            if (Session["member"] == null)
            {
                return View("Shopping", "_Layout", product);
            }
            return View("Shopping", "_Layoutmember", product);
        }

        public ActionResult Tv()
        {
            var product = shopping.tproducts.ToList();
            if (Session["member"] == null)
            {
                return View("Index", "_Layout", product);
            }
            return View("Tv", "_Layoutmember", product);
        }

        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(string fuserid, string fpwd)
        {
            var member = shopping.tmembers
                .Where(m => m.fuserid == fuserid && m.fpwd == fpwd)
                .FirstOrDefault();
            
            if (member == null)
            {
                ViewBag.Message = "帳號密碼錯誤，重新登入";
                return View();
            }
            Session["welcome"] = member.fname ;
            Session["member"] = member;
            return RedirectToAction("Index");
        }

        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Register(tmember pmembr)
        {

            if (ModelState.IsValid == false)
            {

                return View();
            }
            var member = shopping.tmembers
                .Where(m => m.fuserid == pmembr.fuserid)
                .FirstOrDefault();
            if (member == null)
            {
                shopping.tmembers.Add(pmembr);
                shopping.SaveChanges();

                return RedirectToAction("Login");
            }
            ViewBag.Message = "此帳號已被使用，註冊失敗";
            return View();
        }

        public ActionResult Log()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult Shoppingcart()
        {
            string fuserid = (Session["member"] as tmember).fuserid;

            var orderdetails = shopping.torderdetails.Where(m => m.fuserid == fuserid && m.fisapproved == "否").ToList();
            return View("Shoppingcart", "_Layoutmember", orderdetails);
        }

        [HttpPost]
        public ActionResult Shoppingcart(string freceiver, string femail, string faddress)
        {
            string fuserid = (Session["member"] as tmember).fuserid;

            string guid = Guid.NewGuid().ToString();

            torder order = new torder();
            order.forderguid = guid;
            order.fuserid = fuserid;
            order.freceiver = freceiver;
            order.femail = femail;
            order.faddress = faddress;
            order.fdate = DateTime.Now;

            shopping.torders.Add(order);
            var carlist = shopping.torderdetails.Where(m => m.fisapproved == "否" && m.fuserid == fuserid).ToList();
            foreach (var item in carlist)
            {
                item.forderguid = guid;
                item.fisapproved = "是";
            }

            shopping.SaveChanges();
            return RedirectToAction("OrderList");
        }

        public ActionResult AddCar(string fpid)
        {
            string fuserid = (Session["member"] as tmember).fuserid;

            var currentcar = shopping.torderdetails.Where(m => m.fpid == fpid && m.fisapproved == "否" && m.fuserid == fuserid).FirstOrDefault();
            if (currentcar == null)
            {
                var product = shopping.tproducts.Where(m => m.fpid == fpid).FirstOrDefault();

                torderdetail orderdetail = new torderdetail();
                orderdetail.fuserid = fuserid;
                orderdetail.fpid = product.fpid;
                orderdetail.fname = product.fname;
                orderdetail.fprice = product.fprice;
                orderdetail.fqty = 1;
                orderdetail.fisapproved = "否";
                shopping.torderdetails.Add(orderdetail);
            }
            else
            {
                currentcar.fqty += 1;
            }
            shopping.SaveChanges();

            return RedirectToAction("Shoppingcart");
        }

        public ActionResult DeleteCar(int fid)
        {
            var orderdetail = shopping.torderdetails.Where(m => m.fid == fid).FirstOrDefault();
            shopping.torderdetails.Remove(orderdetail);
            shopping.SaveChanges();

            return RedirectToAction("Shoppingcart");
        }

        public ActionResult OrderList()
        {
            string fuserid = (Session["member"] as tmember).fuserid;

            var orders = shopping.torders.Where(m => m.fuserid == fuserid).OrderByDescending(m => m.fdate).ToList();
            return View("OrderList", "_Layoutmember", orders);
        }

        public ActionResult OrderDetail(string forderguid)
        {


            var orderdetails = shopping.torderdetails.Where(m => m.forderguid == forderguid).ToList();
            return View("OrderDetail", "_Layoutmember", orderdetails);
        }
    }
}
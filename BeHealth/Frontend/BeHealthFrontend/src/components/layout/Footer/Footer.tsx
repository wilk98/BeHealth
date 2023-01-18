import "./Footer.css";
import Contact from "./Contact";
import Business from "./Business";
import Client from "./Client";
import Policy from "./Policy";

function Footer() {
	return (
		<div className="footer">
			<div className="row">
				<Contact />
				<Business />
				<Client />
				<Policy />
			</div>
			<p className="copyright">
				Copyright &copy; 2023 <br /> by Andrii, Maciej & Piotr
			</p>
		</div>
	);
}

export default Footer;

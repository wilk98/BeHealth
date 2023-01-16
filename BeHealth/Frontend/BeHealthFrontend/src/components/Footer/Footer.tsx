import "./Footer.css";
import Contact from "./Contact";
import Business from "./Business";
import Client from "./Client";
import Policy from "./Policy";

function Footer() {
	return (
		<div className="footer">
			<Contact />
			<Business />
			<Client />
			<Policy />
			<p className="copyright">
				Copyright &copy; 2023 <br /> by Andrii, Maciej & Piotr
			</p>
		</div>
	);
}

export default Footer;

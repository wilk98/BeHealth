import Logo from "../Logo";
import fb from "../images/fb.jpg";
import insta from "../images/insta.jpg";
import twitter from "../images/twitter.jpg";

function Contact() {
	return (
		<div className="contact">
			<Logo />
			<p>Adres: ul. XYZ</p>
			<p>Miasto: ABC</p>
			<p>XXX-XXX-XXX</p>
			<img src={fb} className="fb" alt="facebook logo" />
			<img src={insta} className="insta" alt="instagram logo" />
			<img src={twitter} className="twitter" alt="twitter logo" />
		</div>
	);
}

export default Contact;

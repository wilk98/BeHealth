import "./Logo.css";

interface Logo {
	fontSize?: number;
}

export const Logo = ({ fontSize = 20 }: Logo) => {
	return (
		<p className="logo" style={{ fontSize: fontSize }}>
			<b className="purple">Be</b>Health
		</p>
	);
};

export default Logo;

import { Link } from "react-router-dom";

function Client() {
	return (
		<div className="client">
			<p className="title">Klient</p>
			<p>Cennik usług</p>
			<p>Kategorie</p>
			<p>Prześlij opinię</p>
			<Link to="/arange-visit">Umów wizytę</Link>
		</div>
	);
}

export default Client;

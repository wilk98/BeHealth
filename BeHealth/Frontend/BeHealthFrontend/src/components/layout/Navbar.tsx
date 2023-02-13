import { Logo } from "./Logo";
import { PrimaryButton } from "../ui/PrimaryButton";
import { RiMenu3Line, RiCloseLine } from "react-icons/ri";
import "./Navbar.css";
import { useState } from "react";
import { Link } from "react-router-dom";

const Menu = () => {
	return (
		<ul>
			<li>
				<a href="">O nas</a>
			</li>
			<li>
				<a href="">Kategorie</a>
			</li>
			<li>
				<a href="">Recenzje</a>
			</li>
			<li>
				<a href="">Cennik</a>
			</li>
			<li>
				<a href="">Kontakt</a>
			</li>
		</ul>
	);
};

export const Navbar = () => {
	const [toggleMenu, setToggleMenu] = useState(false);

	return (
		<nav>
			<a href="">
				<Logo fontSize={20} />
			</a>
			<div className="nav_container">
				<Menu />
				<div className="login-links">
					<Link to={"/login"}>Login</Link>
					<PrimaryButton>
						<Link to={"/register"}>Rejestracja</Link>
					</PrimaryButton>
				</div>
			</div>
			<div className="navbar-menu ">
				{toggleMenu ? (
					<RiCloseLine size={36} onClick={() => setToggleMenu(false)} />
				) : (
					<RiMenu3Line size={36} onClick={() => setToggleMenu(true)} />
				)}
				{toggleMenu && (
					<div className="navbar-menu_container drop-down">
						<Menu />
						<div className="login-links">
							<a href="">Login</a>
							<PrimaryButton>
								<a href="">Rejestracja</a>
							</PrimaryButton>
						</div>
					</div>
				)}
			</div>
		</nav>
	);
};

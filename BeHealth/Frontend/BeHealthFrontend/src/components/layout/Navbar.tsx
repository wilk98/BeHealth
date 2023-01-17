import { Logo } from "./Logo"
import { PrimaryButton } from "../ui/PrimaryButton"
import { RiMenu3Line, RiCloseLine } from "react-icons/ri"
import './Navbar.css'
import { useState } from "react"

const Menu = () => {
  return (
    <ul>
      <li><a href="">About</a></li>
      <li><a href="">Categories</a></li>
      <li><a href="">Reviews</a></li>
      <li><a href="">Price</a></li>
      <li><a href="">Contact</a></li>
    </ul>
  )
}


export const Navbar = () => {
  const [toggleMenu, setToggleMenu] = useState(false)

  return (
    <nav>
      <a href=""><Logo fontSize={20} /></a>
      <div className="nav_container">
        <Menu />
        <div className="login-links">
          <a href="">Login</a>
          <PrimaryButton>
            <a href="">Sign Up</a>
          </PrimaryButton>
        </div>
      </div>
      <div className="navbar-menu ">
        {toggleMenu ? <RiCloseLine size={36} onClick={() => setToggleMenu(false)} />
          : <RiMenu3Line size={36} onClick={() => setToggleMenu(true)} />}
        {toggleMenu && (
          <div className="navbar-menu_container drop-down">
            <Menu />
            <div className="login-links">
              <a href="">Login</a>
              <PrimaryButton>
                <a href="">Sign Up</a>
              </PrimaryButton>
            </div>
          </div>
        )}
      </div>
    </nav>
  )
}

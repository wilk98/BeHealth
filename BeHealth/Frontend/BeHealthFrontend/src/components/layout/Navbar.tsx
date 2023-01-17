import { Logo } from "./Logo"
import { PrimaryButton } from "../ui/PrimaryButton"
import './Navbar.css'

export const Navbar = () => {
  return (
    <nav>
        <a href=""><Logo fontSize={20} /></a>
        <ul>
            <li><a href="">About</a></li>
            <li><a href="">Categories</a></li>
            <li><a href="">Reviews</a></li>
            <li><a href="">Price</a></li>
            <li><a href="">Contact</a></li>
        </ul>
        <div className="login-links">
            <a href="">Login</a>
            <PrimaryButton>
                <a href="">Sign Up</a>
            </PrimaryButton>
        </div>
    </nav>
  )
}

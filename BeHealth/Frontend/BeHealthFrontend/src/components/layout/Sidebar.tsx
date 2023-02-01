import './Sidebar.css'
import {  FaRegCalendar, FaRegClipboard, FaRegUser, IoSettingsSharp, FiMessageSquare, GiHealthNormal } from 'react-icons/all'
import { useState } from 'react'
import { Logo } from './Logo';
import { HamburgerButton } from '../ui/HamburgerButton';
import { Link, LinkProps } from 'react-router-dom';

interface Sidebar {
  isOpen: boolean;
  toggle: () => void;
}

export const Sidebar = ({ isOpen, toggle }: Sidebar) => {
  const [selected, setSelected] = useState(0)

  interface Link {
    name: string,
    link: string,
    icon: JSX.Element,
  }

  const links: Array<Link> = [
    {
      name: "Kalendarz",
      link: "/calendar",
      icon: <FaRegCalendar />,
    },
    {
      name: "Nadchodzące wizyty",
      link: "/visits",
      icon: <FaRegClipboard />,
    },
    {
      name: "Profil",
      link: "/",
      icon: <FaRegUser />,
    },
    {
      name: "Wiadomości",
      link: "/",
      icon: <FiMessageSquare />,
    },
    {
      name: "Pacjenci",
      link: "/",
      icon: <GiHealthNormal />,
    },
    {
      name: "Ustawienia",
      link: "/",
      icon: <IoSettingsSharp />,
    },
  ]

  const linkElements = links.map((link, i) => (
    <li key={link.name} onClick={() => setSelected(i)}  className={selected === i ? 'selected ' : ''}>
      <Link to={link.link}>{link.icon} {link.name}</Link>
    </li>
  ))

  return (
    <aside className={!isOpen ? 'hidden' : ''}>
      <div className='controls'>
        <Logo />
        <HamburgerButton isOpen={isOpen} onClick={toggle} />
      </div>
      <ul>
        {linkElements}
      </ul>
    </aside>
  )
}

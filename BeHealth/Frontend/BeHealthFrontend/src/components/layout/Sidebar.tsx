import './Sidebar.css'
import {  FaRegCalendar, FaRegClipboard, FaRegUser, IoSettingsSharp, FiMessageSquare, GiHealthNormal } from 'react-icons/all'
import { useState } from 'react'
import { Logo } from './Logo';
import { HamburgerButton } from '../ui/HamburgerButton';

interface Sidebar {
  isOpen: boolean;
  toggle: () => void;
}

export const Sidebar = ({ isOpen, toggle }: Sidebar) => {
  const [selected, setSelected] = useState(0)

  const links = ["Kalendarz" , "Nadchodzące wizyty", "Profil", "Wiadomości", "Pacjenci","Ustawienia"]
  const icons = [<FaRegCalendar />, <FaRegClipboard />, <FaRegUser />, <FiMessageSquare />, <GiHealthNormal />, <IoSettingsSharp />]

  const linkElements = links.map((link, i) => (
    <li onClick={() => setSelected(i)}  className={selected === i ? 'selected ' : ''}>{icons[i]} {link}</li>
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

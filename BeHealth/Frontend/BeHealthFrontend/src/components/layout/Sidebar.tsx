import './Sidebar.css'
import {  FaRegCalendar, FaRegClipboard, FaRegUser, IoSettingsSharp, FiMessageSquare, GiHealthNormal } from 'react-icons/all'
import { useState } from 'react'

export const Sidebar = () => {
  const [selected, setSelected] = useState(0)

  const links = ["Kalendarz" , "Nadchodzące wizyty", "Profil", "Wiadomości", "Pacjenci", "Ustawienia"]
  const icons = [<FaRegCalendar />, <FaRegClipboard />, <FaRegUser />, <FiMessageSquare />, <GiHealthNormal />, <IoSettingsSharp />  ]

  const linkClass = (selected:number, i: number, collectionLength: number) => {
    let className = selected === i ? 'selected ' : ''
    className += i === collectionLength - 1 ? 'last-item' : ''
    return className;
  }

  const linkElements = links.map((link, i) => (
    <li onClick={() => setSelected(i)}  className={linkClass(selected, i, links.length)}>{icons[i]} {link}</li>
  ))

  return (
    <aside>
      <ul>
        {linkElements}
      </ul>
    </aside>
  )
}

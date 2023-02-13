import React, { AnchorHTMLAttributes, DetailedHTMLProps, ReactNode } from 'react'
import './PrimaryButton.css'

export const PrimaryButton = ({ children, style }: DetailedHTMLProps<AnchorHTMLAttributes<HTMLAnchorElement>, HTMLAnchorElement>) => {
  style = {
    ...style,
    cursor: 'pointer'
  }
  return (
    <button style={style}>{children}</button>
  )
}
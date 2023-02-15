import React, { AnchorHTMLAttributes, DetailedHTMLProps, ReactNode } from 'react'
import './PrimaryButton.css'

export const PrimaryButton = ({ children }: DetailedHTMLProps<AnchorHTMLAttributes<HTMLAnchorElement>, HTMLAnchorElement>) => {
  return (
    <button className='primary-button'>{children}</button>
  )
}
'use client'
import type { Metadata } from "next";
import { Inter } from "next/font/google";
import "./globals.css";
import { Outfit } from "next/font/google";
import Headers from "./_components/Headers";
import { Toaster } from "@/components/ui/toaster";
import { usePathname } from "next/navigation";
import { Dispatch, SetStateAction, useState } from "react";
import { UpdateCartContext } from "./_context/UpdateCartContext";
import {PayPalScriptProvider} from "@paypal/react-paypal-js"
const outfit = Outfit({ subsets: ["latin"] });

// export const metadata: Metadata = {
//   title: "Create Next App",
//   description: "Generated by create next app",
// };

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {

  const param = usePathname();
  const [updateCart,setUpdateCart] = useState(true)
  const showHeader = param=='/sign_in'?false:true
  function toggleUpdateCart() {
    setUpdateCart(updateCart => !updateCart);
  }


  return (
    <PayPalScriptProvider options={{ clientId : (process.env.NEXT_PUBLIC_BACKEND_BASE_CLIENTID)|| ''}}>
    <html lang="en">
      <head>
        <title>My App</title>
      </head>

      <body className={outfit.className}>
      
        <UpdateCartContext.Provider value ={{updateCart,setUpdateCart}}>
         
        {showHeader &&<Headers /> }
        {children} 
        <Toaster/>
        </UpdateCartContext.Provider>
       
      </body>
    </html>
     </PayPalScriptProvider>
  );
}

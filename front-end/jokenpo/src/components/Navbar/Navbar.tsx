import React from "react";
import btgLogo from "../../assets/btg-logo.png";

const Navbar = () => {
  return (
    <nav className="w-full bg-white h-20 flex items-center justify-between p-5">
      <div className="h-full flex items-center">
        <img
          src={btgLogo}
          alt="BTG Logo"
          className="h-10 w-auto object-contain"
        />
      </div>
    </nav>
  );
};

export default Navbar;

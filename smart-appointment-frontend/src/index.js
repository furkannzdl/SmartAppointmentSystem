import React from "react";
import ReactDOM from "react-dom/client"; // ✅ Use "react-dom/client" for React 18
import App from "./App";
import { AuthProvider } from "./context/AuthContext";

const root = ReactDOM.createRoot(document.getElementById("root")); // ✅ Correct way for React 18
root.render(
  <AuthProvider>
    <App />
  </AuthProvider>
);

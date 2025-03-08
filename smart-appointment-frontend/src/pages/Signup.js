import { useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";

const Signup = () => {
  const navigate = useNavigate();
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [role, setRole] = useState("Patient");

  const handleSignup = async (e) => {
    e.preventDefault();
    try {
      await axios.post("http://localhost:5292/api/auth/signup", { username, password, role });
      alert("Signup successful! Please login.");
      navigate("/");
    } catch (error) {
      console.error("Signup failed", error);
      alert("Signup failed. Try again.");
    }
  };

  return (
    <div>
      <h2>Signup</h2>
      <form onSubmit={handleSignup}>
        <input type="text" placeholder="Username" value={username} onChange={(e) => setUsername(e.target.value)} required />
        <input type="password" placeholder="Password" value={password} onChange={(e) => setPassword(e.target.value)} required />
        <select value={role} onChange={(e) => setRole(e.target.value)}>
          <option value="Patient">Patient</option>
          <option value="Doctor">Doctor</option>
          <option value="Admin">Admin</option>
        </select>
        <button type="submit">Signup</button>
      </form>
    </div>
  );
};

export default Signup;

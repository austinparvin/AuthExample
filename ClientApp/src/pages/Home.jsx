import React, { useState } from 'react'
import axios from 'axios'

export function Home() {
  const [fullName, setFullName] = useState('')
  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')

  const [loginEmail, setLoginEmail] = useState('')
  const [loginPassword, setLoginPassword] = useState('')

  const sendNewUserToApi = async () => {
    // Add extra validation logic here
    const resp = await axios.post('/auth/signup', {
      fullName: fullName,
      email: email,
      password: password,
    })
    console.log(resp.data)
  }

  const logUserIntoApi = async () => {
    const resp = await axios.post('/auth/login', {
      email: loginEmail,
      password: loginPassword,
    })
    console.log(resp.data)
  }

  return (
    <div>
      <section className="login">
        <section>
          <label htmlFor="">Email</label>
          <input
            type="text"
            value={loginEmail}
            onChange={e => setLoginEmail(e.target.value)}
          />
        </section>
        <section>
          <label htmlFor="">Password</label>
          <input
            type="password"
            value={loginPassword}
            onChange={e => setLoginPassword(e.target.value)}
          />
        </section>
        <button onClick={logUserIntoApi}>Login</button>
      </section>
      <section className="sign-up">
        <h1>Create a new account</h1>
        <section>
          <label htmlFor="">Full Name</label>
          <input
            type="text"
            value={fullName}
            onChange={e => setFullName(e.target.value)}
          />
        </section>
        <section>
          <label htmlFor="">Email</label>
          <input
            type="text"
            value={email}
            onChange={e => setEmail(e.target.value)}
          />
        </section>
        <section>
          <label htmlFor="">Password</label>
          <input
            type="password"
            value={password}
            onChange={e => setPassword(e.target.value)}
          />
        </section>
        <button onClick={sendNewUserToApi}>Sign Up</button>
      </section>
    </div>
  )
}

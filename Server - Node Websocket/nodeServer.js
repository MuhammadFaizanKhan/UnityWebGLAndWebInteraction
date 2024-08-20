const WebSocket = require('ws');
const wss = new WebSocket.Server({ port: 8080 })

var sockets = [];

wss.on('connection', ws => {
	//var id = ws.upgradeReq.headers['sec-websocket-key'];
	//console.log("New connection id ::", id);
	//w.send(id);
	sockets.push(ws);
	console.log("New client connected"+ ws);

  ws.on('message', message => {
    
	console.log(`Received message => ${message}`)
	
	//var id = ws.upgradeReq.headers['sec-websocket-key'];
	//var mes = JSON.parse(message);
	
	//sockets[message.to].send(mes.message);
	 // console.log('Message on :: ', id);
    //console.log('On message :: ', message);
	sockets.forEach(w=> {
		w.send(message);
	});
  })
  
  ws.send('Welcome by server!')
})
import { Application, Assets, Text, Sprite } from 'pixi.js';

// Create the PixiJS application
// const app = new PIXI.Application({
//     width: 800,
//     height: 600,
//     backgroundColor: 0xffffff,
// });
const main = async () => {
  const app = new Application();

  await app.init({
    width: 800,
    height: 600,
    backgroundColor: 0x666666,
    hello: true
  });

  // Append the view of the application to the HTML document
  //     document.body.appendChild(app.view);
  document.body.appendChild(app.canvas);

  // Load the cookie image
  //     Loader.shared.add('cookie', 'path/to/cookie.png').load(setup);
  const texture = await Assets.load('assets/cookie.png');
  // let sprite = Sprite.from('assets/cookie.png');
  // app.stage.addChild(sprite);

  // Initial game setup
  (()=>{
    console.log('hello');
    
        // Create the cookie sprite
        const cookie = new Sprite(texture);

        // Position the cookie in the center
        cookie.x = app.renderer.width / 2;
        cookie.y = app.renderer.height / 2;
    
        // Center the anchor point
        cookie.anchor.set(0.5);
    
        // Enable interactive mode and set the click handler
        cookie.interactive = true;
        // cookie.buttonMode = true;
        cookie.on('pointerdown', onClick);
        cookie.eventMode = 'static';
    
        // Add the cookie sprite to the stage
        app.stage.addChild(cookie);
    
        // Score display
        const scoreText = new Text({
          text: 'Score: 0',
          style: {
            fontSize: 36,
            fill: 0x000000
          }
        });
        scoreText.x = 20;
        scoreText.y = 20;
        app.stage.addChild(scoreText);
    
        // Initial score
        let score = 0;
    
        // Click handler function
        function onClick() {
          score++;
          scoreText.text = `Score: ${score}`;
        }
  })();
};

main();